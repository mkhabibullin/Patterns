using System.Collections.Generic;
using VisitorBetterImpl.Impl;
using VisitorBetterImpl.Interfaces;

namespace VisitorBetterImpl
{
    public class CommandsManager
    {
        private readonly List<IVisitable> items = new List<IVisitable>();

        public CommandsManager()
        {
            this.items.AddRange(DemoData.GetItems());
        }

        public void PrettyPrint()
        {
            ReportVisitor report = new ReportVisitor();

            foreach (var item in items)
            {
                item.Accept(report.AsVisitor());
            }

            report.Print();
        }

        public void ApproveAll()
        {
            IVisitor[] visitors = GetApproveVisitors();
            foreach (var item in items)
            {
                foreach (var visitor in visitors)
                {
                    item.Accept(visitor);
                }
            }
        }

        private IVisitor[] GetApproveVisitors()
        {
            return new IVisitor[]
            {
                new Visitor(new NewCustomerCommandApporver()),
                new Visitor(new PurchaseOrderCommandApprover()),
                new Visitor(new SalesOrderCommandApprover()),
            };
        }
    }

}
