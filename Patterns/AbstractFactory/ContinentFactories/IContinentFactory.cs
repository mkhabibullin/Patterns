//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IContinentFactory.cs" company="Ingenius Systems">
//    Copyright (c) Ingenius Systems
//    Create on 2016/06/05 by Марат Хабибуллин
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using AbstractFactory.Domain.Animals.Carnivores;
using AbstractFactory.Domain.Animals.Herbivores;

namespace AbstractFactory.ContinentFactories
{
    public interface IContinentFactory
    {
        IHerbivore CreateHerbivore();

        ICarnivore CreateCarnivore();
    }
}