
namespace Decorator.Data
{
    public abstract class LibraryItem<T>
    {
        public static int NumCopes { get; set; }

        public abstract void Display();
    }
}
