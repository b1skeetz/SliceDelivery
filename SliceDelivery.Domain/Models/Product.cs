using SliceDelivery.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SliceDelivery.Domain.Models
{
    public partial class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double CurrentPrice { get; set; }
        public double OldPrice { get; set; }
        public ProductType Category { get; set; }
        public string Image { get; set; }
    }
}
