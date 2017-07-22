using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleDispatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteDispatcherFactory factory = new ConcreteDispatcherFactory();

            var red = new RedCell();
            var blue = new BlueCell();

            var disp = factory.CreateDispatcher();

            var result = red.AcceptVisitor(disp.Visit(blue));
            Console.WriteLine(result);

            Console.Write("Done");
            Console.Read();
        }
    }

    internal interface ICell
    {
        T AcceptVisitor<T>(ICellVisitor<T> visitor);
    }

    internal interface ICellVisitor<out T>
    {
        T Visit(RedCell cell);

        T Visit(BlueCell cell);

        T Visit(GreenCell cell);
    }

    internal class RedCell : ICell
    {
        public string Color
        {
            get { return "красный"; }
        }

        public T AcceptVisitor<T>(ICellVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }

    internal class BlueCell : ICell
    {
        public string Color
        {
            get { return "синий"; }
        }

        public T AcceptVisitor<T>(ICellVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }

    internal class GreenCell : ICell
    {
        public string Color
        {
            get { return "зелёный"; }
        }

        public T AcceptVisitor<T>(ICellVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }

    internal class ConcreteDispatcherFactory
    {
        public ICellVisitor<ICellVisitor<string>> CreateDispatcher()
        {
            return
                new PrototypeDispatcher<string>(Do)
                    .TakeRed.WithRed(Do)
                    .TakeGreen.WithBlue(Do);
        }

        private string Do(ICell a, ICell b)
        {
            var colorRetriever = new ColorRetriever();
            var aColor = a.AcceptVisitor(colorRetriever);
            var bColor = b.AcceptVisitor(colorRetriever);

            return aColor + "\t-->\t" + bColor;
        }

        private string Do(GreenCell a, BlueCell b)
        {
            return "побережье";
        }

        private string Do(RedCell a, RedCell b)
        {
            return "красное на красном";
        }
    }
    internal class ColorRetriever : ICellVisitor<string>
    {
        public string Visit(RedCell cell)
        {
            return cell.Color;
        }

        public string Visit(BlueCell cell)
        {
            return cell.Color;
        }

        public string Visit(GreenCell cell)
        {
            return cell.Color;
        }
    }
    class PrototypeDispatcher<TResult> : ICellVisitor<ICellVisitor<TResult>>
    {
        private readonly Builder<TResult, RedCell> _redBuilder;
        private readonly Builder<TResult, GreenCell> _greenBuilder;
        private readonly Builder<TResult, BlueCell> _blueBuilder;

        public PrototypeDispatcher(Func<ICell, ICell, TResult> generalCase)
        {
            _redBuilder = new Builder<TResult, RedCell>(this, generalCase);
            _blueBuilder = new Builder<TResult, BlueCell>(this, generalCase);
            _greenBuilder = new Builder<TResult, GreenCell>(this, generalCase);
        }

        public IBuilder<TResult, RedCell> TakeRed
        {
            get { return _redBuilder; }
        }

        public IBuilder<TResult, BlueCell> TakeBlue
        {
            get { return _blueBuilder; }
        }

        public IBuilder<TResult, GreenCell> TakeGreen
        {
            get { return _greenBuilder; }
        }

        public ICellVisitor<TResult> Visit(RedCell cell)
        {
            return _redBuilder.Take(cell);
        }

        public ICellVisitor<TResult> Visit(BlueCell cell)
        {
            return _blueBuilder.Take(cell);
        }

        public ICellVisitor<TResult> Visit(GreenCell cell)
        {
            return _greenBuilder.Take(cell);
        }
    }
    internal class Builder<TResult, TA> : IBuilder<TResult, TA>, ICellVisitor<TResult> where TA : ICell
    {
        private Func<TA, RedCell, TResult> _takeRed;
        private Func<TA, BlueCell, TResult> _takeBlue;
        private Func<TA, GreenCell, TResult> _takeGreen;
        private readonly Func<ICell, ICell, TResult> _generalCase;

        private readonly PrototypeDispatcher<TResult> _dispatcher;
        private TA _target;

        public Builder(PrototypeDispatcher<TResult> dispatcher, Func<ICell, ICell, TResult> generalCase)
        {
            _dispatcher = dispatcher;
            _generalCase = generalCase;

            _takeRed = (a, b) => _generalCase(a, b);
            _takeBlue = (a, b) => _generalCase(a, b);
            _takeGreen = (a, b) => _generalCase(a, b);
        }

        public PrototypeDispatcher<TResult> WithRed(Func<TA, RedCell, TResult> toDo)
        {
            _takeRed = toDo;
            return _dispatcher;
        }

        public PrototypeDispatcher<TResult> WithBlue(Func<TA, BlueCell, TResult> toDo)
        {
            _takeBlue = toDo;
            return _dispatcher;
        }

        public PrototypeDispatcher<TResult> WithGreen(Func<TA, GreenCell, TResult> toDo)
        {
            _takeGreen = toDo;
            return _dispatcher;
        }

        public TResult Visit(RedCell cell)
        {
            return _takeRed(_target, cell);
        }

        public TResult Visit(BlueCell cell)
        {
            return _takeBlue(_target, cell);
        }

        public TResult Visit(GreenCell cell)
        {
            return _takeGreen(_target, cell);
        }

        public ICellVisitor<TResult> Take(TA a)
        {
            _target = a;
            return this;
        }

    }
    internal interface IBuilder<TResult, out TA>
    {
        PrototypeDispatcher<TResult> WithRed(Func<TA, RedCell, TResult> toDo);
        PrototypeDispatcher<TResult> WithBlue(Func<TA, BlueCell, TResult> toDo);
        PrototypeDispatcher<TResult> WithGreen(Func<TA, GreenCell, TResult> toDo);
    }
}
