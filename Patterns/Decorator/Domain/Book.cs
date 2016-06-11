using System;

namespace Decorator.Data
{
    public class Book : LibraryItem<Book>
    {
        private string Author;
        private string Title;

        public Book(string author, string title, int copies)
        {
            Author = author;
            Title = title;
            NumCopes = copies;
        }

        public override void Display()
        {
            Console.WriteLine("Book:");
            Console.WriteLine("Author - {0}, Title - {1}, Copes - {2}", Author, Title, NumCopes);
        }
    }
}
