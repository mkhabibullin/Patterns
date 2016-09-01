using System;
using StateStructural.Context;

namespace StateStructural
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account("FIO");

            account.Deposit(500);
            account.Deposit(300);
            account.Deposit(550);

            account.PayInterest();

            account.Withdraw(1000);
            account.Withdraw(500);


            Console.ReadKey();
        }
    }
}
