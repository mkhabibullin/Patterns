//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ICarnivore.cs" company="Ingenius Systems">
//    Copyright (c) Ingenius Systems
//    Create on 2016/06/05 by Марат Хабибуллин
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using AbstractFactory.Domain.Animals.Herbivores;

namespace AbstractFactory.Domain.Animals.Carnivores
{
    public interface ICarnivore
    {
        void Eat(IHerbivore herbivore);
    }
}