namespace VisitorBetterImpl.Interfaces
{
    public interface IVisitor
    {
        void Visit<TElement>(TElement element);
    }

    public interface IVisitor<TElement>
    {
        IVisitor AsVisitor();

        void Visit(TElement element);
    }
}
