using Decorator.Data;

namespace Decorator.Decorators
{
    public abstract class Decorator<T> : LibraryItem<T>
    {
        private LibraryItem<T> Item;

        protected Decorator(LibraryItem<T> item)
        {
            Item = item;
        }

        public override void Display()
        {
            if(Item != null)
            {
                Item.Display();
            }
        }
    }
}
