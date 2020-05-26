using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Pet : IBirthable
    {
        

        public Pet(string name,string birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }
        public string Name { get; private set; }
        public string BirthDate { get; private set; }
    }
}
