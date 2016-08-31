using DecoratorSimple.Component;

namespace DecoratorSimple.ConcreteDecorators
{
    public class CreamDecorator : Decorator
    {
        public CreamDecorator(BakeryComponent component) : base(component)
        {
            NameAdditional = "Creame";
            PriceAdditional = 1.0;
        }
    }
}