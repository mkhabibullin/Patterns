using System;
using VisitorBetterImpl.Interfaces;

namespace VisitorBetterImpl.Impl
{
    public class SalesOrderCommandApprover : IVisitor<NewSalesOrderCommand>
    {
        public IVisitor AsVisitor()
        {
            return new Visitor(this);
        }

        public void Visit(NewSalesOrderCommand salesOrderCommand)
        {
            Console.WriteLine($"Sales Order from {salesOrderCommand.CustomerCode} was approved.");
        }
    }
}
