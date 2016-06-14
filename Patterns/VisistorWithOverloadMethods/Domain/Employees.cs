using System;
using System.Collections.Generic;
using VisistorWithOverloadMethods.Data;

namespace VisistorWithOverloadMethods.Domain
{
    public class Employees : List<Employee>
    {
        public void Attach(Employee employee)
        {
            this.Add(employee);
        }

        public void Detach(Employee employee)
        {
            this.Remove(employee);
        }

        public void Accept<T>(T context, IVisitor<T> visitor)
        {
            foreach (var employee in this)
            {
                employee.Accept(context, visitor);
            }

            Console.WriteLine();
        }
    }
}
