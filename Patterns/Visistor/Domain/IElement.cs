
namespace Visistor.Domain
{
    public interface IElement
    {
        void Accept<T>(T context, Visitor<T> visitor);
    }
}
