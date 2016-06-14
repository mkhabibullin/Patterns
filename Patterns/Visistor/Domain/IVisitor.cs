using System;

namespace Visistor.Domain
{
    public abstract class Visitor<T>
    {
        public void ReflectiveVisit(T context, IElement element)
        {
            var types = new Type[] { typeof(T), element.GetType()};

            var mi = this.GetType().GetMethod("Visit", types);

            if(mi != null)
            {
                mi.Invoke(this, new object[] { context, element });
            }
        }
    }
}
