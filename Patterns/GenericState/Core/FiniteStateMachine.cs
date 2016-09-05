using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace GenericState.Core
{
    public class FiniteStateMachine<T> where T : State<T> 
    {
        public List<T> States { get; } = new List<T>();

        public List<Transition<T>> Transitions { get; } = new List<Transition<T>>();

        public List<T> Stack { get; } = new List<T>();

        public IEnumerable<string> Tokens => Transitions.Select(t => t.Token).Distinct();

        public T CurrentState => Stack.Any() ? Stack.First() : null;

        #region Event

        /// <summary>
        /// Is fired when a transition successfully completes.
        /// </summary>
        public event Action<Transition<T>> Transitioned;

        #endregion

        public void AddTransition(Transition<T> transition)
        {
            if(transition.To != null && !States.Contains(transition.To) || (transition.From != null && !States.Contains(transition.From)))
                throw new ArgumentException($"Parameter {nameof(transition)} is invalid: {nameof(States)} does not contain the required States.", nameof(transition));

            Transitions.Add(transition);
        }

        public void Transition(string token)
        {
            // First check that we have that token defined
            if (!Tokens.Contains(token))
                throw new ArgumentOutOfRangeException(nameof(token), token, "Given token is not defined.");

            // And that we have a transition for this token
            if (!Transitions.Any(t => t.Token == token && t.From == CurrentState))
                    throw new ArgumentOutOfRangeException(nameof(token), token, $"No transition exists for {CurrentState} + {token}.");

            // Get list of possible transitions...
            var possible = Transitions.Where(t => t.From == CurrentState && t.Token == token).ToList();

            // Check validity of transition
            do
            {
                var transition = possible.MinBy(t =>
                {
                    if (t.TransitionMode != Mode.Pop) return 0;
                    var distanceTo = Stack.IndexOf((T)t.To);
                    return distanceTo == -1 ? int.MaxValue : distanceTo;
                });
                switch (transition.TransitionMode)
                {
                    case Mode.Pop:
                        var pop = Stack.IndexOf((T)transition.To);
                        if (pop == -1)
                        {
                            possible.Remove(transition);
                            continue;
                        }
                        for (var i = 0; i < pop; i++)
                            Stack.RemoveAt(0);
                        break;

                    case Mode.Push:
                        transition = Transitions.First(t => t.Token == token && t.From == CurrentState);
                        Stack.Insert(0, (T)transition.To);
                        break;

                    case Mode.PushPop:
                        transition = Transitions.First(t => t.Token == token && t.From == CurrentState);
                        if (Stack.Count > 0) Stack.RemoveAt(0);
                        Stack.Insert(0, (T)transition.To);
                        break;
                }

                CurrentState?.Enter();
                Transitioned?.Invoke(transition);
                return;
            } while (Transitions.Count > 0);
        }
    }
}