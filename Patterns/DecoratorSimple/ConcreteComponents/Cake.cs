using DecoratorSimple.Component;

namespace DecoratorSimple.ConcreteComponents
{
    public class Cake : BakeryComponent
    {
        public override string Name => "Cake Base";
        public override double Price => 200.0;
    }
}