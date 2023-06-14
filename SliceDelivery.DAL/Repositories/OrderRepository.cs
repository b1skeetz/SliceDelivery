using SliceDelivery.DAL.Interfaces;
using SliceDelivery.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SliceDelivery.DAL.Repositories
{
    public class OrderRepository : IBaseRepository<Order>
    {
        private readonly DiplomaContext _db;

        public OrderRepository(DiplomaContext db)
        {
            _db = db;
        }
        
        public async Task Create(Order entity)
        {
            await _db.Orders.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Order> GetAll()
        {
            return _db.Orders;
        }

        public async Task Delete(Order entity)
        {
            _db.Orders.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Order> Update(Order entity)
        {
            _db.Orders.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}