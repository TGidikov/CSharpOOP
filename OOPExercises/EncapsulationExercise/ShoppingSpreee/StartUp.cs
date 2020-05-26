using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpreee
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                List<Person> people = new List<Person>();
                List<Product> products = new List<Product>();


                string[] inputPeople = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string[] inputProducts = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int i = 0; i < inputPeople.Length; i++)
                {
                    string[] currentPerson = inputPeople[i].Split('=');
                    string name = currentPerson[0];
                    decimal money = decimal.Parse(currentPerson[1]);
                    people.Add(new Person(name, money));
                }
                for (int i = 0; i < inputProducts.Length; i++)
                {
                    string[] currentProduct = inputProducts[i].Split('=');
                    string productName = currentProduct[0];
                    decimal productCost = decimal.Parse(currentProduct[1]);
                    products.Add(new Product(productName, productCost));
                }

                string input = Console.ReadLine();
                while (input != "END")
                {
                    string[] inputInfo = input.Split();

                    string name = inputInfo[0];
                    string product = inputInfo[1];

                    Person person = people.FirstOrDefault(x => x.Name == name);
                    Product product1 = products.FirstOrDefault(x => x.Name == product);
                    person.AddToBag(product1);


                    input = Console.ReadLine();

                }
                foreach (var person in people)
                {

                    Console.WriteLine(person);

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
                
              
            
        }
    }
}
