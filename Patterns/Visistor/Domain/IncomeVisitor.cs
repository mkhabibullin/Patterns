using System;
using Visistor.Data;

namespace Visistor.Domain
{
    public class IncomeVisitor : Visitor<float>
    {
        public void Visit(float context, Clerk clerk)
        {
            DoVisit(context, clerk);
        }

        public void Visit(float context, President element)
        {
            DoVisit(context, element);
        }

        ///// <summary>
        ///// COMMON
        ///// </summary>
        //public void Visit(int context, IElement element)
        //{
        //    DoVisit(context, element);
        //}

        private void DoVisit(float context, IElement element)
        {
            var employee = element as Employee;

            employee.Income *= context;

            Console.WriteLine("{0} {1}'s new income : {2:C}",
                employee.GetType().Name, employee.Name,
                employee.Income);
        }
    }
}
