using DecoratorSimple.Component;

namespace DecoratorSimple.ConcreteDecorators
{
    public class ArtificialScentDecorator : Decorator
    {
        public ArtificialScentDecorator(BakeryComponent component) : base(component)
        {
            NameAdditional = "Artificial Scent";
            PriceAdditional = 3.0;
        }
    }
}