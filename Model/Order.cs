﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order
    {
        public readonly Recipe Recipe;

        public Order(ref Recipe recipe) => Recipe = recipe;

    }
}
