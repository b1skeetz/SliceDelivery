using System.Linq;
using System.Threading.Tasks;
using SliceDelivery.DAL.Interfaces;
using SliceDelivery.Domain.Models;

namespace SliceDelivery.DAL.Repositories
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly DiplomaContext _db;

        public UserRepository(DiplomaContext db)
        {
            _db = db;
        }

        public IQueryable<User> GetAll()
        {
            return _db.Users;
        }

        public async Task Delete(User entity)
        {
            _db.Users.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Create(User entity)
        {
            await _db.Users.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<User> Update(User entity)
        {
            _db.Users.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}