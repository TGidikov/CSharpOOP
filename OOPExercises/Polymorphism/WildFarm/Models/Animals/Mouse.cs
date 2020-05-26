﻿using System;
using WildFarm.Models.Foods;
using System.Collections.Generic;

namespace WildFarm.Models.Animals
{
    
    public class Mouse : Mammal      
    {
        private const double WEIGHT_MULTIPLIER = 0.10;

        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier => WEIGHT_MULTIPLIER;

        public override ICollection<Type> PrefferedFoods => 
            new List<Type>() { typeof(Vegetable), typeof(Fruit) };

        public override string ProduceSound()
        {
            return "Squeak";
        }
        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {FoodEaten}]";
        }
    }
}
