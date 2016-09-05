using GenericState.Core;

namespace GenericState.States
{
    public class StateBase : State<StateBase>
    {
        protected StateBase(FiniteStateMachine<StateBase> stateMachine) : base(stateMachine)
        {
        }
    }
}