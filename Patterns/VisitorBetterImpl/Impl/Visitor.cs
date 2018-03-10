using VisitorBetterImpl.Interfaces;

namespace VisitorBetterImpl.Impl
{
    public class Visitor : IVisitor
    {
        private readonly object specificVisitor;

        public Visitor(object specificVisitor)
        {
            this.specificVisitor = specificVisitor;
        }

        public void Visit<TElement>(TElement element)
        {
            IVisitor<TElement> visitor = specificVisitor as IVisitor<TElement>;
            visitor?.Visit(element);
        }
    }
}
