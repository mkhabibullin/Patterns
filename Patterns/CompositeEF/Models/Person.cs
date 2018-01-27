using CompositeEF.Core;
using System.Collections.Generic;

namespace CompositeEF.Models
{
    public class Person : BookItem
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }

        public Person()
        {
            this.Addresses = new List<Address>();
        }

        public override void Accept(IBookVisitor visitor)
        {
            visitor.BeginVisit(this);

            foreach (Address address in this.Addresses)
            {
                address.Accept(visitor);
            }

            visitor.EndVisit(this);
        }
    }
}
