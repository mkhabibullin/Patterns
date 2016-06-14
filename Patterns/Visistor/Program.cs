using System;
using Visistor.Data;
using Visistor.Domain;

namespace Visistor
{ 
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new Employees();
            employees.Add(new Clerk());
            employees.Add(new Director());
            employees.Add(new President());

            employees.Accept(1.10f, new IncomeVisitor());
            employees.Accept(10, new VacationVisitor());

            Console.ReadLine();
        }
    }
}
