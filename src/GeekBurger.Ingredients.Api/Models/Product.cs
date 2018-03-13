﻿using System;
using System.Collections.Generic;

namespace GeekBurger.Ingredients.Api.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
