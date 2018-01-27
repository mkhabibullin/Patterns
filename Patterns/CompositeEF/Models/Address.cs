using CompositeEF.Core;

namespace CompositeEF.Models
{
    public class Address
    {
        public int ID { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }

        public virtual Person Parent { get; set; }

        public int PersonID { get; set; }

        public void Accept(IBookVisitor visitor)
        {
            visitor.BeginVisit(this as dynamic);
            visitor.EndVisit(this as dynamic);
        }
    }
}
