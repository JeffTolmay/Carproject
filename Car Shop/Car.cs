﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Shop
{
    public class Car
    {
        public int id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string RegNo { get; set; }
        public string Cost { get; set; }
        public float total { get; set; }
        public float Comm { get; set; }
        public string Fullinfo
        {
            get
            {
                return $"{Make} {Model} {Color} {RegNo}";
            }
        }
    }
}
