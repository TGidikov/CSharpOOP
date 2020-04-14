using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fishCollection;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fishCollection = new List<IFish>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Capacity { get; }


        public ICollection<IDecoration> Decorations => this.decorations.AsReadOnly();

        public ICollection<IFish> Fish => this.fishCollection.AsReadOnly();
        public int Comfort => this.decorations.Sum(d=>d.Comfort);
        public void AddFish(IFish fish)
        {
            if (Fish.Count==this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
            
            this.fishCollection.Add(fish);
        }
        public bool RemoveFish(IFish fish) => this.fishCollection.Remove(fish);
        

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }


        public void Feed()
        {
            foreach (var fish in this.fishCollection)
            {
                fish.Eat();
            }
        }

        public virtual string GetInfo()
        {
          
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            sb.Append("Fish: ");
            if (this.fishCollection.Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                    sb.AppendLine(string.Join(", ",fishCollection.Select(f=>f.Name)));
                
               
            }
            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
            



        }

    }
}
