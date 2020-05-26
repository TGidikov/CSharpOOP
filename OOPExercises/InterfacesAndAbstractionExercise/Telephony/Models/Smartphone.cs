using System;
using System.Linq;
using Telephony.Contracts;

namespace Telephony.Models
{
    public class Smartphone : IBrowsable,ICallable
    {
        public Smartphone()
        {

        }
        public string Browse(string url)
        {
            if (url.Any(ch => char.IsDigit(ch)))
            {
                throw new Exception("Invalid URL!");
            }
            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if (!number.All(ch => char.IsDigit(ch)))
            {
                throw new Exception("Invalid number!");
            }
            return $"Calling... {number}";
        }
    }
}
