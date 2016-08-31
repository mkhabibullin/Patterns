using DecoratorSimple.Component;

namespace DecoratorSimple.ConcreteDecorators
{
    public class CherryDecorator : Decorator
    {
        public CherryDecorator(BakeryComponent component) : base(component)
        {
            NameAdditional = "Cherry";
            PriceAdditional = 2.0;
        }
    }
}