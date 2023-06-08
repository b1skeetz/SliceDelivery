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

        public async Task<bool> Create(Product entity)
        {
            await _db.Products.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Product entity)
        {
            _db.Products.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Product> Get(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> GetByName(string name)
        {
            return await _db.Products.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<Product>> Select()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> Update(Product entity)
        {
            _db.Products.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
