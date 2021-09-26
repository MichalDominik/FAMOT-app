using Fridge.Repository.Context;
using Fridge.Service.Interfaces;
using Fridge.Service.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fridge.Repository.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(FridgeDbContext context) : base(context) { }

        public override async Task<List<Product>> GetAll()
        {
            return await Database.Products.Include(prod => prod.Category)
                .OrderBy(prod => prod.Name)
                .ToListAsync();
        }
    }
}
