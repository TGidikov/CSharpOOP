﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Cargo
    {
        public int Weight { get; }
        public string Type { get; }
        public Cargo(int weight,string type)
        {
            this.Weight = weight;
            this.Type =type;
        }
       
    }
}