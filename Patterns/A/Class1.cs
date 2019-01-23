namespace Protected
{
    namespace Internal
    {
        public class A
        {
            protected internal int x = 10;
        }

        public class Main
        {
            void Do()
            {
                var a = new A();

                // X is available due to Internal
                a.x = 1000;
            }
        }
    }

    namespace Private
    {
        public class A
        {
            private protected int x = 10;
        }
    }
}
