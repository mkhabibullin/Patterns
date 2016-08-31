using System;
using DecoratorSimple.Component;
using DecoratorSimple.ConcreteComponents;
using DecoratorSimple.ConcreteDecorators;

namespace DecoratorSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            Cake cake = new Cake();
            PrintProductDetails(cake);

            CreamDecorator creameDecorator = new CreamDecorator(cake);
            PrintProductDetails(creameDecorator);

            CherryDecorator cherryDecorator = new CherryDecorator(creameDecorator);
            PrintProductDetails(cherryDecorator);

            ArtificialScentDecorator artificialScentDecorator = new ArtificialScentDecorator(cherryDecorator);
            PrintProductDetails(artificialScentDecorator);

            // Lets now create a simple Pastry
            Pastry pastry = new Pastry();
            PrintProductDetails(pastry);

            // Lets just add cream and cherry only on the pastry 
            CreamDecorator creamPastry = new CreamDecorator(pastry);
            CherryDecorator cherryPastry = new CherryDecorator(creamPastry);
            PrintProductDetails(cherryPastry);

            Console.Read();
        }

        static void PrintProductDetails(BakeryComponent product)
        {
            Console.WriteLine();
            Console.WriteLine($"Item: {product.Name}, Price: {product.Price}");
        }
    }
}
