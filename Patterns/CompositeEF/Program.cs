using CompositeEF.Models;
using CompositeEF.Visitors;
using System;

namespace CompositeEF
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var factory = new SampleDbContextFactory())
            {
                // Get a context
                using (var context = factory.CreateContext())
                {
                    Group root = new Group() { Name = "~" };
                    context.Items.Add(root);

                    Person ori = new Person() { FirstName = "Ori", LastName = "Calvo" };
                    root.Items.Add(ori);
                    ori.Addresses.Add(new Address() { Value = "ori.calvo@gmail.com" });
                    ori.Addresses.Add(new Address() { Value = "ori_calvo@hotmail.com" });
                    
                    Group friends = new Group() { Name = "Friends" };
                    root.Items.Add(friends);
                    
                    Person yossi = new Person() { FirstName = "Yossi", LastName = "Halul" };
                    friends.Items.Add(yossi);
                    
                    context.SaveChanges();
                }

                // Get another context using the same connection
                using (var context = factory.CreateContext())
                {
                    PrintVisitor print = new PrintVisitor();
                    context.Root.Accept(print);

                    //var count = context.Users.Count();
                    //Assert.AreEqual(1, count);

                    //var u = context.Users.FirstOrDefault(user => user.Email == "test@sample.com");
                    //Assert.IsNotNull(u);
                }
            }

            Console.WriteLine("Is over!");
            Console.Read();
        }
    }
}
