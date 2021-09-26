using Fridge.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fridge.Service.Interfaces
{
    public interface ICategoryService : IDisposable
    {
        Task<Category> Add(Category category);
        Task<Category> Update(Category category);
        Task<bool> Remove(Category category);
        Task<IEnumerable<Category>> GetAll();
        Task<IEnumerable<Category>> Search(string categoryName);
    }
}
