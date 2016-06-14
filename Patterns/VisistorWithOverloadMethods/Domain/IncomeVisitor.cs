using System;
using VisistorWithOverloadMethods.Data;

namespace VisistorWithOverloadMethods.Domain
{
    public class IncomeVisitor : IVisitor<double>
    {
        public void Visit(double context, President president)
        {
            DoVisit(context * 10, president);
        }

        public void Visit(double context, Employee employee)
        {
            DoVisit(context, employee);
        }

        public void Visit(double context, Director director)
        {
            DoVisit(context * 10, director);
        }

        //public void Visit(double context, Clerk clerk)
        //{
        //    DoVisit(context, clerk);
        //}

        private void DoVisit(double context, IElement element)
        {
            var employee = element as Employee;

            employee.Income *= context;

            Console.WriteLine("{0} {1}'s new income : {2:C}",
                employee.GetType().Name, employee.Name,
                employee.Income);
        }
    }
}
