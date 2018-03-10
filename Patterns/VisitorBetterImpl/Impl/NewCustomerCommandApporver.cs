using System;
using VisitorBetterImpl.Interfaces;

namespace VisitorBetterImpl.Impl
{
    public class NewCustomerCommandApporver : IVisitor<NewCustomerCommand>
    {
        public IVisitor AsVisitor()
        {
            return new Visitor(this);
        }

        public void Visit(NewCustomerCommand customerCommand)
        {
            Console.WriteLine($"We have new customer! {customerCommand.Name} welcome!");
        }
    }
}
