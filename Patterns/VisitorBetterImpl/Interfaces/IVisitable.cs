namespace VisitorBetterImpl.Interfaces
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}
