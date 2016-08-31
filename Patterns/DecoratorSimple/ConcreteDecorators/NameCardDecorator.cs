using DecoratorSimple.Component;

namespace DecoratorSimple.ConcreteDecorators
{
    public class NameCardDecorator : Decorator
    {
        private int DiscountRate = 5;

        public NameCardDecorator(BakeryComponent component) : base(component)
        {
            NameAdditional = "Name Card";
            PriceAdditional = 4.0;
        }

        public override string Name => base.Name + $"\n(Please Collect your discount card for {DiscountRate}%)";
    }
}