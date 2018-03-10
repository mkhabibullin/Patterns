using System;
using VisitorBetterImpl.Interfaces;

namespace VisitorBetterImpl.Impl
{
    public class PurchaseOrderCommandApprover : IVisitor<NewPurchaseOrderCommand>
    {
        public IVisitor AsVisitor()
        {
            return new Visitor(this);
        }

        public void Visit(NewPurchaseOrderCommand purchaseOrder)
        {
            Console.WriteLine($"Purchase of: {purchaseOrder.Product.Name} was approved.");
        }
    }
}
