using System;

namespace InvariationDelegate
{
    class Program
    {
        delegate Person PersonFactory(string name); // Проверка ковариантности

        delegate void ClientInfo(Client client); // Проверка контрвариантности

        static void Main(string[] args)
        {
            PersonFactory personDel = BuildPerson;
            PersonFactory clientDel = BuildClient; // ковариантность

            clientDel = personDel;

            Person p = clientDel("Tom");
            p.Display();
            Console.Read();

            ClientInfo clientInfo = GetPersonInfo; // контравариантность
            Client client = new Client("Alice");
            clientInfo(client);

            Console.Read();

        }

        private static Client BuildClient(string name)
        {
            return new Client(name);
        }

        private static Person BuildPerson(string name)
        {
            return new Person(name);
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
        public void Display()
        {
            Console.WriteLine(Name);
        }
    }
    class Client : Person
    {
        public Client(string name) : base(name)
        {
        }
    }

    class Staff : Client
    {
        public Staff(string name) : base(name)
        {
        }
    }
}
