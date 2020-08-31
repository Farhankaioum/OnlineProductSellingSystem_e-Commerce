using Etsy.T_Shirt_Store.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Etsy.T_Shirt_Store.Framework
{
    public class Product : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public bool Available { get; set; }
    }
}
