using System;
using GenericState.Core;

namespace GenericState.States
{
    public class StartState : StateBase
    {
        public StartState(FiniteStateMachine<StateBase> stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Console.WriteLine("Enter StartState");
            StateMachine.Transition("next");
        }
    }
}