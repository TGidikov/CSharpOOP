using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private readonly List<string> items;

        public Planet(string name)
        {
            this.Name = name;
            this.items = new List<string>();
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
                    throw new ArgumentNullException("Invalid name!");
                }
                this.name = value;
            }
        }

        public ICollection<string> Items =>this.items.AsReadOnly();

        public void AddItems(string[] planetItems)
        {
            foreach (var item in planetItems)
            {
                items.Add(item);
            }
        }
        public void RemoveItem(string item)
        {
            items.Remove(item);
        }
       



    }
}
