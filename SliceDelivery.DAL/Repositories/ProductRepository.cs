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
    public class ProductRepository : IBaseRepository<Product>
    {
        private readonly DiplomaContext _db;
        public ProductRepository(DiplomaContext db)
        {
            _db = db;
        }

        public async Task Create(Product entity)
        {
            await _db.Products.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Product> GetAll()
        {
            return _db.Products;
        }

        public async Task Delete(Product entity)
        {
            _db.Products.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Product> Update(Product entity)
        {
            _db.Products.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
