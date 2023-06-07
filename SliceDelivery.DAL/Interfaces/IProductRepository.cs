using SliceDelivery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SliceDelivery.DAL.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Product GetByName(string name);
    }
}
