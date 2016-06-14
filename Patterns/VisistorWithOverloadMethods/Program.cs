using System;
using VisistorWithOverloadMethods.Data;
using VisistorWithOverloadMethods.Domain;

namespace VisistorWithOverloadMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new Employees();
            employees.Add(new Clerk()); // Visit as Employee (Employee visitor.Visit(context, this as dynamic);
            employees.Add(new Director());
            employees.Add(new President());

            employees.Accept(1.10f, new IncomeVisitor());
            employees.Accept(10, new VacationVisitor());

            Console.ReadLine();
        }
    }
}
