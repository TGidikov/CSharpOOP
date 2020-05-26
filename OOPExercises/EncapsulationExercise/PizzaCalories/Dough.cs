using System;
using System.Collections.Generic;
using System.Text;
 
namespace PizzaCalories
{
   public  class Dough
	{
		Dictionary<string, double> flourTypes;
		Dictionary<string, double> bakingTechniques;
		private string flourType;
		private string bakingTechnique;
		private double CALORIES_PER_GRAM = 2;
		public Dough(string flourType,string bakingTechnique,double weight)
		{
			this.FlourType = flourType;
			this.BakingTechnique = bakingTechnique;
			this.Weight = weight;
		}
	
		public string FlourType
		{
			get { return flourType; }
			set
			{
				if (!DoughValidator.IsValidFlourType(value))
				{
					throw new Exception("Invalid type of dough.");
				}
				flourType = value; 
			}
		}

		public string BakingTechnique

		{
			get { return bakingTechnique; }
			set 
			{
				if (!DoughValidator.IsValidBakingTechnique(value))
				{
					throw new Exception("Invalid type of dough.");
				}

				bakingTechnique = value; 
			
			}
		}
		private double weight;

		public double Weight
		{
			get { return weight; }
			set 
			{
				if (value<1 || value>200 )
				{
					throw new Exception("Dough weight should be in the range [1..200].");
				}
				weight = value;
			}
		}
		public double GetTotalCalories()
		{
			return this.Weight * CALORIES_PER_GRAM * DoughValidator.GetFlourModifier(this.FlourType) *
					DoughValidator.GetBakingModifier(this.BakingTechnique);
		}

	}
}
