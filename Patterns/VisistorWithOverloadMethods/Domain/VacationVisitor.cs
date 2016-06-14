using System;
using VisistorWithOverloadMethods.Data;

namespace VisistorWithOverloadMethods.Domain
{
    public class VacationVisitor : IVisitor<int>
    {
        public void Visit(int context, President president)
        {
            DoVisit(context, president);
        }

        public void Visit(int context, Employee employee)
        {
            DoVisit(context, employee);
        }

        public void Visit(int context, Director director)
        {
            DoVisit(context, director);
        }

        //public void Visit(int context, Clerk clerk)
        //{
        //    DoVisit(context, clerk);
        //}

        private void DoVisit(int context, IElement element)
        {
            var employee = element as Employee;

            employee.VacationDays += context;

            Console.WriteLine("{0} {1}'s new vacation days: {2}",
                employee.GetType().Name, employee.Name, employee.VacationDays);
        }
    }
}
