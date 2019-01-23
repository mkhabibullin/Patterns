namespace Protected
{
    namespace Internal
    {
        public class B : A
        {
            public B()
            {
                x = 11;
            }
        }
    }

    namespace Private
    {
        public class B : A
        {
            public B()
            {
                //x = 11; // Compile exception
            }
        }
    }
}
