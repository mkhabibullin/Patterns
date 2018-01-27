using CompositeEF.Core;
using CompositeEF.Models;
using System;

namespace CompositeEF.Visitors
{
    public class PrintVisitor : BookVisitor
    {
        private int ident;

        public PrintVisitor()
        {
            this.ident = 0;
        }

        public override void BeginVisit(Person person)
        {
            WriteLine(person.FirstName + ", " + person.LastName);

            ++this.ident;
        }

        public override void EndVisit(Person person)
        {
            --this.ident;
        }

        public override void BeginVisit(Address address)
        {
            WriteLine(address.Value);
        }

        public override void BeginVisit(Group group)
        {
            WriteLine(group.Name);

            ++this.ident;
        }

        public override void EndVisit(Group group)
        {
            --this.ident;
        }

        private void WriteLine(string message)
        {
            for (int i = 0; i < this.ident * 4; i++)
            {
                Console.Write(" ");
            }

            Console.WriteLine(message);
        }
    }
}
