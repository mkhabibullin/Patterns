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

            Console.WriteLine("GENRIC INTERFACE");

            var driver = DriverFactory.Get(1);
            driver.Do();

            driver = DriverFactory.Get(2);
            driver.Do();

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

    class Base
    {

    }

    interface IBase<T> where T : Base
    {
        void Dot(T t);
    }

    class A : Base
    {
        
    }

    class Service : IBase<A>
    {
        public void Dot(A t)
        {
            throw new NotImplementedException();
        }
    }

    ////////////// GENERIC FACTORY TEST
    
    public abstract class DiverDataBase
    {

    }
    public abstract class DiverDataInBase
    {

    }

    public class DiverData : DiverDataBase
    {
        public string Name { get; set; }
    }

    public class DiverDataIn : DiverDataInBase
    {
        public string Name { get; set; }
    }

    public interface IDriver<out TOut>
    {
        TOut Do();
    }

    public class DiverDataNew : DiverDataBase
    {
        public string Name { get; set; }
    }

    public class DiverDataOutNew : DiverDataInBase
    {
        public string Name { get; set; }
    }

    public class Driver : IDriver<DiverData>
    {
        public DiverData Do()
        {
            Console.WriteLine("Generic");
            return new DiverData { Name = "Generic" };
        }
    }

    public class DriverNew : IDriver<DiverDataNew>
    {
        public DiverDataNew Do()
        {
            Console.WriteLine("Generic New");
            return new DiverDataNew { Name = "Generic new" };
        }
    }

    public static class DriverFactory
    {
        public static IDriver<DiverDataBase> Get(int type)
        {
            if (type == 1)
            {
                return new Driver();
            }
            else if(type == 2)
            {
                return new DriverNew();
            }
            return null;
        }
    }
}
