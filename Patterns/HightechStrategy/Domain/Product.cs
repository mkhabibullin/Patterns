﻿namespace HightechStrategy.Domain
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public User User { get; set; }
    }
}
