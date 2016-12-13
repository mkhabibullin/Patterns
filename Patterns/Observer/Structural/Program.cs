using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure Observer pattern
            ConcreteSubject s = new ConcreteSubject();

            s.Attach(new ConcreteObserver(s, "X"));
            s.Attach(new ConcreteObserver(s, "Y"));
            s.Attach(new ConcreteObserver(s, "Z"));

            // Change subject and notify observers
            s.SubjectState = "ABC";
            s.Notify();

            // Wait for user
            Console.ReadKey();
        }
    }

    abstract class Subject
    {
        private List<Observer> _observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach(Observer o in _observers)
            {
                o.Update();
            }
        }
    }

    class ConcreteSubject: Subject
    {
        public string SubjectState { get; set; }
    }

    abstract class Observer
    {
        public abstract void Update();
    }

    class ConcreteObserver : Observer
    {
        private string _name;
        private string _observerState;

        public ConcreteSubject Subject { get; set; }

        public ConcreteObserver(ConcreteSubject subject, string name)
        {
            this._name = name;
            this.Subject = subject;
        }

        public override void Update()
        {
            _observerState = Subject.SubjectState;
            Console.WriteLine($"Observer {_name}'s new state is {_observerState}");
        }
    }
}
