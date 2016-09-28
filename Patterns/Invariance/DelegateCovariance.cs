using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Invariance
{
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
