using Decorator.Data;
using System;
using System.Collections.Generic;

namespace Decorator.Decorators
{
    public class Barrowable<T> : Decorator<T>
    {
        private List<string> borrowers = new List<string>();

        public Barrowable(LibraryItem<T> item) : base(item)
        {
        }

        public void BorrowItem(string name)
        {
            borrowers.Add(name);
            NumCopes--;
        }

        public void ReturnItem(string name)
        {
            borrowers.Remove(name);
            NumCopes++;
        }

        public override void Display()
        {
            base.Display();

            foreach(var bs in borrowers)
            {
                Console.WriteLine(" borrower: " + bs);
            }
        }
    }
}
