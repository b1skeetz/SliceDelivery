﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SliceDelivery.Domain.Models;

namespace SliceDelivery.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product>? Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Diploma;Username=postgres;Password=postgres");
        }
    }
}