using CompositeEF.Core;
using System.Collections.Generic;

namespace CompositeEF.Models
{
    public class Group : BookItem
    {
        public string Name { get; set; }
        public virtual ICollection<BookItem> Items { get; set; }

        public Group()
        {
            this.Items = new List<BookItem>();
        }

        public override void Accept(IBookVisitor visitor)
        {
            visitor.BeginVisit(this as dynamic);

            foreach (BookItem item in this.Items)
            {
                item.Accept(visitor);
            }

            visitor.EndVisit(this as dynamic);
        }
    }
}
