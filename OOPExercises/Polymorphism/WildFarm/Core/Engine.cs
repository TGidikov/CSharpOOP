using System;
using System.Linq;
using WildFarm.Factories;
using WildFarm.Exceptions;
using WildFarm.Models.Animals;
using WildFarm.Core.Contracts;
using System.Collections.Generic;
using WildFarm.Models.Animals.Contracts;
using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private ICollection<IAnimal>animals;

        private FoodFactory foodFactory;
        public Engine()
        {
            this.animals = new List<IAnimal>();
            this.foodFactory = new FoodFactory();
        }

        public void Run()
        {
            string command;
            while ((command=Console.ReadLine())!="End")
            {
                var animalArgs = command.
                    Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var foodArg = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                IAnimal animal=ProduceAnimal(animalArgs);
                IFood food = this.foodFactory.ProduceFood(foodArg[0], 
                    int.Parse(foodArg[1]));
                this.animals.Add(animal);
                Console.WriteLine(animal.ProduceSound());
                try
                {
                    animal.Feed(food);

                }
                catch (UneatableFoodException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }


            foreach (IAnimal animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }


        private static IAnimal ProduceAnimal(string[] animalArgs)
        {
            var animalType = animalArgs[0];
            var name = animalArgs[1];
            var weight = double.Parse(animalArgs[2]);
            IAnimal animal = null;
            if (animalType == "Owl")
            {
                var wingSize = double.Parse(animalArgs[3]);
                animal = new Owl(name, weight, wingSize);

            }
            else if (animalType == "Hen")
            {
                var wingSize = double.Parse(animalArgs[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else
            {
                var livingRegion = animalArgs[3];
                if (animalType == "Dog")
                {
                    animal = new Dog(name, weight, livingRegion);
                }
                else if (animalType == "Mouse")
                {
                    animal = new Mouse(name, weight, livingRegion);
                }
                else
                {
                    var breed = animalArgs[4];
                    if (animalType == "Cat")
                    {
                        animal = new Cat(name,weight,livingRegion,breed);
                    }
                    else if (animalType == "Tiger")
                    {
                        animal = new Tiger(name, weight, livingRegion, breed);
                    }
                }
            }

           return animal;
        }
    }
}
