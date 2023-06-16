using SliceDelivery.DAL.Interfaces;
using SliceDelivery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliceDelivery.DAL.Repositories
{
    public class MailerRepository : IBaseRepository<Mailers>
    {
        private readonly DiplomaContext _db;

        public MailerRepository(DiplomaContext dbContext)
        {
            _db = dbContext;
        }

        public async Task Create(Mailers entity)
        {
            await _db.Mailers.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Mailers> GetAll()
        {
            return _db.Mailers;
        }

        public async Task Delete(Mailers entity)
        {
            _db.Mailers.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Mailers> Update(Mailers entity)
        {
            _db.Mailers.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

    }
}
