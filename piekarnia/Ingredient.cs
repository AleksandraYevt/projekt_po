﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piekarnia
{
    class Ingredient
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }

        public string DisplayQuantity
        {
            get { return $"{Quantity} {Unit}"; }
        }
    }
}
