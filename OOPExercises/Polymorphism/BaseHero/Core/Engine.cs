using Raiding.Core.Contracts;
using Raiding.Factories;
using System;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            int totalPower = 0;
            for (int i = 0; i < n; i++)
            {
               
                    var name = Console.ReadLine();
                    var type = Console.ReadLine();
                    PowerFactory powerFactory = new PowerFactory();
                try { 

                    if (type == "Druid")
                    {
                        var hero = new Druid(name);
                        Console.WriteLine(hero.CastAbility());
                        totalPower += powerFactory.AddPower(hero);
                    }
                    else if (type == "Paladin")
                    {
                        var hero = new Paladin(name);
                        Console.WriteLine(hero.CastAbility());
                        totalPower += powerFactory.AddPower(hero);
                    }
                    else if (type == "Rogue")
                    {
                        var hero = new Rogue(name);
                        Console.WriteLine(hero.CastAbility());
                        totalPower += powerFactory.AddPower(hero);
                    }
                    else if (type == "Warrior")
                    {
                        var hero = new Warrior(name);
                        Console.WriteLine(hero.CastAbility());
                        totalPower += powerFactory.AddPower(hero);
                    }
                    else
                    {
                        throw new Exception("Invalid hero!");
                      
                    }

                }
                catch (Exception ex )
                {

                    Console.WriteLine(ex.Message);
                   
                }

            }
            var bossHealth = int.Parse(Console.ReadLine());
            if (totalPower >= bossHealth)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
