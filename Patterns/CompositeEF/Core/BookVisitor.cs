using CompositeEF.Models;

namespace CompositeEF.Core
{
    public class BookVisitor : IBookVisitor
    {
        public virtual void BeginVisit(Person person)
        {
        }

        public virtual void EndVisit(Person person)
        {
        }

        public virtual void BeginVisit(Group group)
        {
        }

        public virtual void EndVisit(Group group)
        {
        }

        public virtual void BeginVisit(Address address)
        {
        }

        public virtual void EndVisit(Address address)
        {
        }
    }
}
