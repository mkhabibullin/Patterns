using System;
using System.Reflection;

namespace HightechStrategy
{
    public abstract class State<T>
        where T : class
    {
        protected State(T entity)
        {
            Entity = entity
                ?? throw new ArgumentNullException(nameof(entity));
        }

        protected T Entity { get; }
    }

    public static class StateCodeExtensions
    {
        public static State<T> ToState<T>(this Enum stateCode, object entity)
            where T : class
            // да, да reflection медленный. Замените компилируемыми expression tree
            // или IL Emit и будет быстро
            => (State<T>)Activator.CreateInstance(stateCode
                .GetType()
                .GetCustomAttribute<StateAttribute>()
                .StateType, entity);
    }
}
