using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DynamicObject
{
    class Program
    {
        static void Main(string[] args)
        {
            var csvModel = new CsvDynamicModel();

            csvModel.SetProperty("Id", 1);
            csvModel["Name"] = "Some Name";

            Console.WriteLine("Done!");
            Console.Read();
        }
    }

    /// <summary>
    /// https://download.microsoft.com/download/5/4/B/54B83DFE-D7AA-4155-9687-B0CF58FF65D7/implementing-dynamic-interfaces.pdf
    /// </summary>
    public class CsvDynamicModel : IDynamicMetaObjectProvider
    {
        private readonly Dictionary<string, object> _dynamicProperties = new Dictionary<string, object>();

        private PropertyInfo[] _staticProperties = null;

        public void SetProperty(string key, object value)
        {
            if (TryGetStaticProperty(key, out var staticProperty))
            {
                staticProperty.SetValue(this, value);
                return;
            }
            _dynamicProperties[key] = value;
        }

        public object this[string key]
        {
            get => GetProperty(key);
            set => SetProperty(key, value);
        }

        public object GetProperty(string key)
        {
            if (TryGetStaticProperty(key, out var staticProperty))
            {
                return staticProperty.GetValue(this);
            }
            return _dynamicProperties[key];
        }

        public bool TryGetProperty(string key, out object value)
        {
            if (TryGetStaticProperty(key, out var staticProperty))
            {
                value = staticProperty.GetValue(this);
                return true;
            }
            return _dynamicProperties.TryGetValue(key, out value);
        }

        private bool TryGetStaticProperty(string key, out PropertyInfo propertyInfo)
        {
            if (_staticProperties == null)
            {
                _staticProperties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            }
            propertyInfo = _staticProperties.FirstOrDefault(property => property.Name == key);
            return propertyInfo != null;
        }

        #region IDynamicMetaObjectProvider

        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new DynamicCsvMetaObject(parameter, this, _dynamicProperties);
        }

        private class DynamicCsvMetaObject : DynamicMetaObject
        {
            Dictionary<string, object> _dynamicProperties;

            internal DynamicCsvMetaObject(Expression parameter,
            CsvDynamicModel value,
            Dictionary<string, object> dynamicProperties)
            : base(parameter, BindingRestrictions.Empty, value)
            {
                _dynamicProperties = dynamicProperties;
            }

            public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
            {
                return new DynamicMetaObject(
                Expression.Call(
                Expression.Convert(Expression, LimitType),
                typeof(CsvDynamicModel).GetMethod(nameof(CsvDynamicModel.GetProperty)),
                new[] { Expression.Constant(binder.Name) }),
                BindingRestrictions.GetTypeRestriction(Expression, LimitType));
            }

            public override IEnumerable<string> GetDynamicMemberNames()
            {
                return Value
                .GetType()
                .GetProperties()
                .Where(p => p.GetIndexParameters().Length == 0) // Except Indexers
                .Select(prop => prop.Name)
                .Concat(_dynamicProperties.Keys);
            }
        }

        #endregion
    }
}
