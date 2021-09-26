using Fridge.Service.Interfaces;
using Fridge.Service.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fridge.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductService _productService;

        public CategoryService(ICategoryRepository categoryRepository, IProductService productService)
        {
            _categoryRepository = categoryRepository;
            _productService = productService;
        }
        public async Task<Category> Add(Category category)
        {
            if (_categoryRepository.Search(cat => cat.Name == category.Name).Result.Any())
            {
                return null;
            }
            await _categoryRepository.Add(category);
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            if (_categoryRepository.Search(cat => cat.Name == category.Name && cat.Id != category.Id).Result.Any())
            {
                return null;
            }
            await _categoryRepository.Update(category);
            return category;
        }

        public async Task<bool> Remove(Category category)
        {
            var products = await _productService.GetAll();
            foreach (var product in products)
            {
                if (product.CategoryId == category.Id)
                {
                    return false;
                }
            }
            await _categoryRepository.Remove(category);
            return true;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<IEnumerable<Category>> Search(string categoryName)
        {
            return await _categoryRepository.Search(cat => cat.Name.Contains(categoryName));
        }

        public void Dispose()
        {
            _categoryRepository?.Dispose();
        }
    }
}
