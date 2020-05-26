using System;
using WildFarm.Models.Foods;
using System.Collections.Generic;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double WEIGHT_MULTIPLIER = 0.35;
        public Hen(string name, double weight, double wingsize) 
            : base(name, weight, wingsize)
        {
        }

        public override double WeightMultiplier => WEIGHT_MULTIPLIER;

        public override ICollection<Type> PrefferedFoods => new List<Type>() 
        { typeof(Vegetable),typeof(Fruit),typeof(Meat),typeof(Seeds) };

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
