using Fridge.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fridge.Service.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        new Task<List<Product>> GetAll();
    }
}
