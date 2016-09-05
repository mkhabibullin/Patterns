using System;
using GenericState.Core;
using GenericState.FiniteStateMachine;
using GenericState.States;

namespace GenericState
{
    /// <summary>
    /// https://github.com/Sidneys1/GFSM
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var fsm = new MyFiniteStateMachine();
            var start = new StartState(fsm);
            var end = new EndState(fsm);
            fsm.States.Add(start);
            fsm.States.Add(end);

            fsm.AddTransition(new Transition<StateBase>("start", null, start));
            fsm.AddTransition(new Transition<StateBase>("next", start, end));
            fsm.AddTransition(new Transition<StateBase>("next", end, null));

            fsm.Transitioned += t => {
                Console.WriteLine(t);
                if (t.To == null)
                    Console.WriteLine("Exited!");
            };

            // We can transition into StartState from a null state
            fsm.Transition("start");

            Console.Read();
        }
    }
}
