using Fridge.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fridge.Service.Interfaces
{
    public interface IProductService : IDisposable
    {
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task<bool> Remove(Product product);
        Task<IEnumerable<Product>> GetAll();
        Task<IEnumerable<Product>> Search(string productName);
    }
}
