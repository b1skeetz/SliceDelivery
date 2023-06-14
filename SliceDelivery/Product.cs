using System;
using System.Collections.Generic;

#nullable disable

namespace SliceDelivery
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double CurrentPrice { get; set; }
        public double OldPrice { get; set; }
        public int Category { get; set; }
        public string Image { get; set; }
    }
}
