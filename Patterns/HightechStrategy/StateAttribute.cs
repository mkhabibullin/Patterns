using System;

namespace HightechStrategy
{
    [AttributeUsage(AttributeTargets.Field)]
    public class StateAttribute : Attribute
    {
        public Type StateType { get; }

        public StateAttribute(Type stateType)
        {
            StateType = stateType
                ?? throw new ArgumentNullException(nameof(stateType));
        }
    }
}
