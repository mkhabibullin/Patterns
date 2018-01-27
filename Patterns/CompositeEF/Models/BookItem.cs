using CompositeEF.Core;

namespace CompositeEF.Models
{
    public abstract class BookItem
    {
        public int ID { get; set; }
        public virtual Group Parent { get; set; }
        public int? GroupID { get; set; }

        public abstract void Accept(IBookVisitor visitor);
    }
}
