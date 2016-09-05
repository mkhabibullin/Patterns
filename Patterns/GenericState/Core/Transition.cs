namespace GenericState.Core
{
    public class Transition<T> where T : State<T>
    {
        public string Token { get; }
        public State<T> To { get; }
        public State<T> From { get; }
        public Mode TransitionMode { get; }

        public Transition(string token, State<T> from, State<T> to, Mode mode = Mode.Push)
        {
            Token = token;
            To = to;
            From = from;
            TransitionMode = mode;
        }

        public override bool Equals(object obj)
        {
            var t = obj as Transition<T>;
            if (t == null) return false;
            return t.Token == Token && t.To == To && t.From == From && t.TransitionMode == TransitionMode;
        }

        public override int GetHashCode()
        {
            return Token.GetHashCode() ^ To?.GetHashCode() ?? 0 ^ From?.GetHashCode() ?? 0 ^ TransitionMode.GetHashCode();
        }

        public override string ToString()
        {
            return $"{From} + '{Token}' = {To}";
        }
    }
}