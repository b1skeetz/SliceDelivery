﻿using SliceDelivery.DAL.Interfaces;
using SliceDelivery.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SliceDelivery.DAL.Repositories
{
    public class BasketRepository : IBaseRepository<Basket>
    {
        private readonly DiplomaContext _db;

        public BasketRepository(DiplomaContext dbContext)
        {
            _db = dbContext;
        }

        public async Task Create(Basket entity)
        {
            await _db.Baskets.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Basket> GetAll()
        {
            return _db.Baskets;
        }

        public async Task Delete(Basket entity)
        {
            _db.Baskets.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Basket> Update(Basket entity)
        {
            _db.Baskets.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

    }   
}