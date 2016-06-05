//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AnimalWorld.cs" company="Ingenius Systems">
//    Copyright (c) Ingenius Systems
//    Create on 2016/06/05 by Марат Хабибуллин
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using AbstractFactory.ContinentFactories;
using AbstractFactory.Domain.Animals.Carnivores;
using AbstractFactory.Domain.Animals.Herbivores;

namespace AbstractFactory.Services
{
    public class AnimalWorld<T> : IAnimalWorld where T : IContinentFactory, new()
    {
        private IHerbivore herbivore;
        private ICarnivore carnivore;

        private T factory;

        public AnimalWorld()
        {
            factory = new T();

            carnivore = factory.CreateCarnivore();
            herbivore = factory.CreateHerbivore();
        } 

        public void RunFoodChain()
        {
            carnivore.Eat(herbivore);
        }
    }
}