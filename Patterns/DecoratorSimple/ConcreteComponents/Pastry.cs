using DecoratorSimple.Component;

namespace DecoratorSimple.ConcreteComponents
{
    public class Pastry : BakeryComponent
    {
        public override string Name => "Pastery Base";
        public override double Price => 20.0;
    }
}