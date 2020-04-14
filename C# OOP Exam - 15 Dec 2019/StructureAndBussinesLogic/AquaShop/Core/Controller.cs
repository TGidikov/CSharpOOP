using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IAquarium> aquariums;
        private readonly IRepository<IDecoration> decorations;

        public Controller()
        {
            this.aquariums = new List<IAquarium>();
            this.decorations = new DecorationRepository();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType=="FreshwaterAquarium")
            {
                aquariums.Add(new FreshwaterAquarium(aquariumName));
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquariums.Add(new SaltwaterAquarium(aquariumName));
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }

            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                decorations.Add(new Ornament());
            }
            else if (decorationType == "Plant")
            {
                decorations.Add(new Plant());
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            return $"Successfully added {decorationType}.";
        }
        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = decorations.Models.FirstOrDefault(d => d.GetType().Name == decorationType);      
            if (decoration==null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
            var aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);
            return $"Successfully added {decorationType} to {aquariumName}.";

        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;

            if (fishType=="FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType=="SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }
            var messege = string.Empty;
            var aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            if (fishType=="FreshwaterFish" && aquarium.GetType().Name=="FreshwaterAquarium")
            {
                aquarium.AddFish(fish);
                messege = $"Successfully added {fishType} to {aquariumName}.";
            }
            else if (fishType == "SaltwaterFish" && aquarium.GetType().Name == "SaltwaterAquarium")
            {
                aquarium.AddFish(fish);
                messege = $"Successfully added {fishType} to {aquariumName}.";
            }
            else
            {
                messege = "Water not suitable.";
            }


            return messege;

        }
        public string FeedFish(string aquariumName)
        {
            var count = 0;
            var aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            foreach (var fish in aquarium.Fish)
            {
                fish.Eat();
                count++;
            }
            return $"Fish fed: {count}";
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
           var fishesTotalPrice = aquarium.Fish.Sum(f => f.Price);
            var decorationTotalPrice = aquarium.Decorations.Sum(d => d.Price);
            var total = fishesTotalPrice + decorationTotalPrice;
            return $"The value of Aquarium {aquariumName} is {total:F2}.";

           
        }



        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.Append(aquarium.GetInfo());
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd();
        }
    }
}
