//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Lion.cs" company="Ingenius Systems">
//    Copyright (c) Ingenius Systems
//    Create on 2016/06/05 by Марат Хабибуллин
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
using System;
using AbstractFactory.Domain.Animals.Herbivores;

namespace AbstractFactory.Domain.Animals.Carnivores
{
    public class Lion : ICarnivore
    {
        public void Eat(IHerbivore herbivore)
        {
            Console.WriteLine(this.GetType().Name + " eats " + herbivore.GetType().Name);
        }
    }
}