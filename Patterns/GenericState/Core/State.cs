namespace GenericState.Core
{
    /// <summary>
    /// FSM
    /// </summary>
    /// <typeparam name="T">State</typeparam>
    public abstract class State<T> where T : State<T>
    {
        public FiniteStateMachine<T> StateMachine { get; }

        protected State(FiniteStateMachine<T> stateMachine)
        {
            StateMachine = stateMachine;
        }

        public virtual void Enter()
        {
            
        }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}