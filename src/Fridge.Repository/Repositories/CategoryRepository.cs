using Fridge.Repository.Context;
using Fridge.Service.Interfaces;
using Fridge.Service.Models;

namespace Fridge.Repository.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(FridgeDbContext context) : base(context) { }
    }
}
