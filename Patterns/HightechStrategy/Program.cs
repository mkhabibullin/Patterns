using HightechStrategy.Domain;
using System;
using static HightechStrategy.Cart;

namespace HightechStrategy
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://habrahabr.ru/post/341134/

            var user = new User();

            var cart = new Cart(user);

            var state = new ActiveCartState(cart);
            cart.State = state;
            //cart.StateCode = CartStateCode.Empty;

            var p = new Product();

            state.Add(p);

            state.Clear();
            state.Remove(p);

            Console.Write("Done");
            Console.Read();
        }
    }
}
