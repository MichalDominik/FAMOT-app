using Fridge.Service.Interfaces;
using Fridge.Service.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fridge.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Add(Product product)
        {
            if (_productRepository.Search(prod => prod.Name == product.Name).Result.Any())
            {
                return null;
            }
            await _productRepository.Add(product);
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            if (_productRepository.Search(prod => prod.Name == product.Name && prod.Id != product.Id).Result.Any())
            {
                return null;
            }
            await _productRepository.Update(product);
            return product;
        }

        public async Task<bool> Remove(Product product)
        {
            await _productRepository.Remove(product);
            return true;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<IEnumerable<Product>> Search(string productName)
        {
            return await _productRepository.Search(prod => prod.Name.Contains(productName));
        }

        public void Dispose()
        {
            _productRepository?.Dispose();
        }
    }
}
