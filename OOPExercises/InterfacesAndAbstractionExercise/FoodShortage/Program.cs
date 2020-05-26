using System;
using System.Collections.Generic;

namespace FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var citizens = new List<Citizen>();
            var rebels = new List<Rebel>();
            var totalFood = 0;
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var age = int.Parse(input[1]);
               
                if (input.Length==4)
                {
                    var id = input[2];
                    var birthday = input[3];
                    Citizen citizen = new Citizen(name, age, id, birthday);
                    citizens.Add(citizen);
                }
                if (input.Length==3)
                {
                    var group = input[2];
                    var rebel = new Rebel(name, age, group);
                    rebels.Add(rebel);
                }

            }
            string command;
            while ((command= Console.ReadLine())!="End")
            {
                foreach (var citizen in citizens)
                {
                    if (citizen.Name==command)
                    {
                        citizen.BuyFood();
                        totalFood += citizen.Food;
                        citizen.Food = 0;
                    }
                }
                foreach (var rebel in rebels)
                {
                    if (rebel.Name==command)
                    {
                        rebel.BuyFood();
                        totalFood += rebel.Food;
                        rebel.Food = 0;

                    }
                }
            }



            Console.WriteLine(totalFood);

        }
    }
}
