using VisistorWithOverloadMethods.Data;

namespace VisistorWithOverloadMethods.Domain
{
    public interface IVisitor<T>
    {
        void Visit(T context, Employee employee);

        //void Visit(T context, Clerk clerk);
        void Visit(T context, Director director);
        void Visit(T context, President president);
    }
}
