using System;
using WildFarm.Models.Foods;
using System.Collections.Generic;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double WEIGHT_MULTIPLIER = 0.25;
        public Owl(string name, double weight, double wingsize) : 
            base(name, weight, wingsize)
        {
        }

        public override double WeightMultiplier => WEIGHT_MULTIPLIER;

        public override ICollection<Type> PrefferedFoods => 
            new List<Type>() { typeof(Meat) };

        public override string ProduceSound()
        {
            return $"Hoot Hoot";
        }
    }
}
