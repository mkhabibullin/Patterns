//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Africa.cs" company="Ingenius Systems">
//    Copyright (c) Ingenius Systems
//    Create on 2016/06/05 by Марат Хабибуллин
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using AbstractFactory.Domain.Animals.Carnivores;
using AbstractFactory.Domain.Animals.Herbivores;

namespace AbstractFactory.ContinentFactories
{
    public class Africa : IContinentFactory
    {
        public IHerbivore CreateHerbivore()
        {
            return new Wildbeest();
        }

        public ICarnivore CreateCarnivore()
        {
            return new Lion();
        }
    }
}