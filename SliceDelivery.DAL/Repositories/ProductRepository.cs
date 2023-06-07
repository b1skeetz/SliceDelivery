using Microsoft.EntityFrameworkCore;
using SliceDelivery.DAL.Interfaces;
using SliceDelivery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliceDelivery.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DiplomaContext _db;
        public ProductRepository(DiplomaContext db)
        {
            _db = db;
        }

        public bool Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> Select()
        {
            return _db.Products.ToListAsync();
        }
    }
}
