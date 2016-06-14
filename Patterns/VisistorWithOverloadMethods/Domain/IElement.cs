
namespace VisistorWithOverloadMethods.Domain
{
    public interface IElement
    {
        void Accept<T>(T context, IVisitor<T> visitor);
    }
}
