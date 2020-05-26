using System.Collections.Generic;
using System;
using System.Linq;

namespace BirthdayCelebrations
{

    class StartUp
    {
        static void Main(string[] args)
        {
            var birthDays = new HashSet<string>();
            string input;

            while ((input=Console.ReadLine())!="End")
            {
               var data=input.Split().ToArray(); ;
                if (data[0]=="Citizen")
                {
                    var name = data[1];
                    var age = int.Parse(data[2]);
                    var id = data[3];
                    
                    var birthDay =data [4];
                    Citizen citizen = new Citizen(name, age, id, birthDay);
                    birthDays.Add(birthDay);
                }
                else if (data[0]=="Pet")
                {
                    var name = data[1];
                    var birthdayPet = data[2];
                    Pet pet = new Pet(name, birthdayPet);
                    birthDays.Add(birthdayPet);
                }
                else if (data[0]=="Robot")
                {
                    var model = data[1];
                    var id = data[2];
                    Robot robot = new Robot(model, id);
                }
            }
            string year = Console.ReadLine();
            foreach (var birthDay in birthDays)
            {
                if (birthDay.EndsWith(year))
                {
                    Console.WriteLine(birthDay);
                }
            }



        }
    }
}
