using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Invariance
{
    /////////////////////////////////
    /// http://metanit.com/sharp/tutorial/3.28.php
    ///////////////////////////////////
    
    /// <summary>
    /// ---------------------------------------------------------------------------------------
    /// COVARIANCE
    /// ---------------------------------------------------------------------------------------
    /// </summary>
    [TestClass]
    public class DelegateCovariance
    {
        delegate Person PersonFactory(string name);

        [TestMethod]
        public void TestMethod1()
        {
            PersonFactory personDel;
            personDel = BuildClient; // ковариантность
            Person p = personDel("Tom");
            p.Display();
        }

        private static Client BuildClient(string name)
        {
            return new Client(name);
        }
    }

    /// <summary>
    /// ---------------------------------------------------------------------------------------
    /// CONTRVARIANCE
    /// ---------------------------------------------------------------------------------------
    /// </summary>
    [TestClass]
    public class DelegateContrVariance
    {
        delegate void ClientInfo(Client client);

        [TestMethod]
        public void TestMethod1()
        {
            ClientInfo clientInfo = GetPersonInfo; // контравариантность
            var client = new Client("Alice");
            clientInfo(client);
        }
        private static void GetPersonInfo(Person p)
        {
            p.Display();
        }
    }

    /// <summary>
    /// ---------------------------------------------------------------------------------------
    /// GENERIC COVARIANCE
    /// ---------------------------------------------------------------------------------------
    /// </summary>
    [TestClass]
    public class GenericDelegateCovariance
    {
        delegate T Builder<out T>(string name);

        [TestMethod]
        public void Test1()
        {
            Builder<Person> personBuilder = GetPerson;
            Builder<Client> clientBuilder = GetClient;

            personBuilder = clientBuilder; // Covariance

            //clientBuilder = personBuilder; // COMPILE ERROR

            Person p = personBuilder("Tom");
            p.Display();
        }

        private static Person GetPerson(string name)
        {
            return new Person(name);
        }

        private static Client GetClient(string name)
        {
            return new Client(name);
        }
    }

    [TestClass]
    public class GenericDelegateContrvariance
    {
        delegate void GetInfo<in T>(T item);

        [TestMethod]
        public void Test1()
        {
            GetInfo<Person> personInfo = PersonInfo;
            GetInfo<Client> clientInfo = ClientInfo;

            clientInfo = personInfo; // Contrvariance

            Client client = new Client("Tom");
            clientInfo(client);
        }

        [TestMethod]
        public void Test2()
        {
            Action<Person> b = (target) => { Trace.WriteLine(target.GetType().Name); };
            Action<Client> d = b;
            d(new Client("Tom2"));
        }

        private static void PersonInfo(Person p)
        {
            p.Display();
        }

        private static void ClientInfo(Client c)
        {
            c.Display();
        }
    }

    // ----------------------------------------------------------------------------------------
    // DOMAIN
    // ----------------------------------------------------------------------------------------

    class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }
        public virtual void Display()
        {
            Trace.WriteLine($"Person name is {Name}");
        }
    }
    class Client : Person
    {
        public Client(string name) : base(name)
        {
        }

        public override void Display()
        {
            Trace.WriteLine($"Client name is {Name}");
        }
    }

    class Staff : Client
    {
        public Staff(string name) : base(name)
        {
        }
    }
}
