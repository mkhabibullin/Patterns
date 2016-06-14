using Visistor.Domain;

namespace Visistor.Data
{
    public abstract class Employee : IElement
    {
        public string Name { get; set; }
        public double Income { get; set; }
        public int VacationDays { get; set; }

        protected Employee(string name, double income, int vacationDays)
        {
            this.Name = name;
            this.Income = income;
            this.VacationDays = vacationDays;
        }

        public virtual void Accept<T>(T context, Visitor<T> visitor)
        {
            visitor.ReflectiveVisit(context, this);
        }
    }

    public class Clerk : Employee
    {
        public Clerk() : base("Hank", 25000.0, 14)
        {

        }
    }

    public class Director : Employee
    {
        public Director() : base("Elly", 35000.0, 16)
        {

        }
    }

    public class President : Employee
    {
        public President() : base("Dick", 45000.0, 21)
        {

        }
    }
}
