using VisistorWithOverloadMethods.Domain;

namespace VisistorWithOverloadMethods.Data
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

        public virtual void Accept<T>(T context, IVisitor<T> visitor)
        {
            visitor.Visit(context, this as dynamic);
        }
    }

    public class Clerk : Employee
    {
        public Clerk() : base("Hank", 25000.0, 14)
        {

        }

        //public override void Accept<T>(T context, IVisitor<T> visitor)
        //{
        //    visitor.Visit(context, this);
        //}
    }

    public class Director : Employee
    {
        public Director() : base("Elly", 35000.0, 16)
        {

        }

        //public override void Accept<T>(T context, IVisitor<T> visitor)
        //{
        //    visitor.Visit(context, this);
        //}
    }

    public class President : Employee
    {
        public President() : base("Dick", 45000.0, 21)
        {

        }

        //public override void Accept<T>(T context, IVisitor<T> visitor)
        //{
        //    visitor.Visit(context, this);
        //}
    }
}
