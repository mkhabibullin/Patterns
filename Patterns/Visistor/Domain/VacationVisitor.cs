using System;
using Visistor.Data;

namespace Visistor.Domain
{
    public class VacationVisitor : Visitor<int>
    {
        public void Visit(int context, President element)
        {
            DoVisit(context, element);
        }

        /// <summary>
        /// COMMON
        /// </summary>
        public void Visit(int context, IElement element)
        {
            DoVisit(context, element);
        }

        private void DoVisit(int context, IElement element)
        {
            var employee = element as Employee;

            employee.VacationDays += context;

            Console.WriteLine("{0} {1}'s new vacation days: {2}",
                employee.GetType().Name, employee.Name, employee.VacationDays);
        }
    }
}
