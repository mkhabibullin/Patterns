using DecoratorSimple.Component;

namespace DecoratorSimple
{
    public abstract class Decorator : BakeryComponent
    {
        private BakeryComponent Component { get; set; }

        protected string NameAdditional = "Undefinde decorator";
        protected double PriceAdditional = 0.0;

        protected Decorator(BakeryComponent component)
        {
            Component = component;
        }

        public override string Name => $"{Component.Name}, {NameAdditional}";

        public override double Price => PriceAdditional + Component.Price;
    }
}