using System;
using GenericState.Core;

namespace GenericState.States
{
    public class EndState : StateBase
    {
        public EndState(FiniteStateMachine<StateBase> stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Console.WriteLine("Entered EndState");
            StateMachine.Transition("next");
        }
    }
}