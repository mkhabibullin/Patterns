using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator.Data;
using Decorator.Decorators;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Some body", "best of the best", 10);
            book.Display();

            Video video = new Video("Some people", 120, 10);
            video.Display();

            Console.WriteLine("\nMaking video borrowable: ");

            Barrowable<Video> borrow = new Barrowable<Video>(video);
            borrow.BorrowItem("People 1");
            borrow.BorrowItem("People 2");

            borrow.Display();

            Console.ReadLine();
        }
    }
}
