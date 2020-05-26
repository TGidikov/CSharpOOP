using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Contracts;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public StationaryPhone()
        {
           
        }
      

        public string Call(string number)
        {
            if (!number.All(ch => char.IsDigit(ch)))
            {
                throw new Exception("Invalid number!");
            }
            return $"Dialing... {number}";
        }
    }
}
