using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliceDelivery.Domain.ViewModels.Product
{
    public class ProductViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double CurrentPrice { get; set; }
        public double OldPrice { get; set; }
        public string Category { get; set; }
        public IFormFile Avatar { get; set; }
        public byte[] Image { get; set; }
    }
}
