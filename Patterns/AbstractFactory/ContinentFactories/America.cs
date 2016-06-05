//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="America.cs" company="Ingenius Systems">
//    Copyright (c) Ingenius Systems
//    Create on 2016/06/05 by Марат Хабибуллин
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using AbstractFactory.Domain.Animals.Carnivores;
using AbstractFactory.Domain.Animals.Herbivores;

namespace AbstractFactory.ContinentFactories
{
    public class America : IContinentFactory
    {
        public IHerbivore CreateHerbivore()
        {
            return new Bison();
        }

        public ICarnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }
}