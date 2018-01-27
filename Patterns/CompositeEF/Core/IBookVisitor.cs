using CompositeEF.Models;

namespace CompositeEF.Core
{
    public interface IBookVisitor
    {
        void BeginVisit(Person person);
        void EndVisit(Person person);

        void BeginVisit(Group group);
        void EndVisit(Group group);

        void BeginVisit(Address address);
        void EndVisit(Address address);
    }
}
