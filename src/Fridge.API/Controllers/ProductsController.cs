using AutoMapper;
using Fridge.API.Dtos.Product;
using Fridge.Service.Interfaces;
using Fridge.Service.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fridge.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : MainController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddDto productDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var product = _mapper.Map<Product>(productDto);
            var productResult = await _productService.Add(product);

            if (productResult == null) return BadRequest();

            return Ok(_mapper.Map<ProductResultDto>(productResult));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ProductEditDto productDto)
        {
            if (id != productDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            await _productService.Update(_mapper.Map<Product>(productDto));

            return Ok(productDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var products = await _productService.GetAll();
            Product productToRemove = null;
            foreach (var product in products)
            {
                if (product.Id == id)
                {
                    productToRemove = product;
                }
            }
            if (productToRemove == null) return NotFound();

            var result = await _productService.Remove(productToRemove);

            if (!result) return BadRequest();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();

            if (products == null) return NotFound();

            return Ok(_mapper.Map<IEnumerable<ProductResultDto>>(products));
        }

        [Route("search/{productName}")]
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Search(string productName)
        {
            var products = _mapper.Map<List<Product>>(await _productService.Search(productName));

            if (products == null || products.Count == 0) return NotFound();

            return Ok(products);
        }
    }
}
