using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invaration
{
    class Program
    {
        static void Main(string[] args)
        {

            //Account account = new Account();
            //IBank<Account> ordinaryBank = new Bank<Account>();
            //ordinaryBank.DoOperation(account);

            //DepositAccount depositAcc = new DepositAccount();
            //IBank<DepositAccount> depositBank = ordinaryBank;
            //ordinaryBank.DoOperation(depositAcc);

            //Console.ReadLine();

            IBank<DepositAccount> depositBank = new Bank();
            depositBank.DoOperation();

            IBank<Account> ordinaryBank = depositBank;
            ordinaryBank.DoOperation();

            Console.ReadLine();
        }
    }

    class Account
    {
        static Random rnd = new Random();

        public virtual void DoTransfer()
        {
            int sum = rnd.Next(10, 120);
            Console.WriteLine(sum);
        }
    }

    class DepositAccount : Account
    {
        public override void DoTransfer()
        {
            Console.WriteLine(1);
        }
    }

    //interface IBank<in T> where T : Account
    //{
    //    void DoOperation(T account);
    //}

    //class Bank<T> : IBank<T> where T : Account
    //{
    //    public void DoOperation(T account)
    //    {
    //        account.DoTransfer();
    //    }
    //}

    interface IBank<out T> where T : Account
    {
        T DoOperation();
    }

    class Bank : IBank<DepositAccount>
    {
        public DepositAccount DoOperation()
        {
            DepositAccount acc = new DepositAccount();
            acc.DoTransfer();
            return acc;
        }
    }
}
