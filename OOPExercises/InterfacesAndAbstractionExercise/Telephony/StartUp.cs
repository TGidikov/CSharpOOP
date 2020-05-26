using System;
using System.Linq;
using Telephony.Models;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var phoneNumbers = Console.ReadLine()
                 .Split()
                 .ToArray();
            var sites = Console.ReadLine()
                .Split()
                .ToArray();
            CallNumber(phoneNumbers);
            BrowseURL(sites);

        }

        private static void BrowseURL(string[] sites)
        {
            Smartphone smartphone = new Smartphone();
            foreach (var url in sites)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(url));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }
        }

        private static void CallNumber(string[] phoneNumbers)
        {
            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();
            foreach (var phoneNumber in phoneNumbers)
            {
                try
                {
                    if (phoneNumber.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(phoneNumber));

                    }
                    else if (phoneNumber.Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(phoneNumber));
                    }
                    else
                    {
                        throw new Exception("Invalid number!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
