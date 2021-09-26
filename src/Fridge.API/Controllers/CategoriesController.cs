using AutoMapper;
using Fridge.API.Dtos.Category;
using Fridge.Service.Interfaces;
using Fridge.Service.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fridge.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : MainController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var category = _mapper.Map<Category>(categoryDto);
            var categoryResult = await _categoryService.Add(category);

            if (categoryResult == null) return BadRequest();

            return Ok(_mapper.Map<CategoryResultDto>(categoryResult));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, CategoryEditDto categoryDto)
        {
            if (id != categoryDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            await _categoryService.Update(_mapper.Map<Category>(categoryDto));

            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var categories = await _categoryService.GetAll();
            Category categoryToRemove = null;
            foreach (var category in categories)
            {
                if (category.Id == id)
                {
                    categoryToRemove = category;
                }
            }
            if (categoryToRemove == null) return NotFound();

            var result = await _categoryService.Remove(categoryToRemove);

            if (!result) return BadRequest();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAll();

            if (categories == null) return NotFound();

            return Ok(_mapper.Map<IEnumerable<CategoryResultDto>>(categories));
        }

        [Route("search/{category}")]
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Search(string category)
        {
            var categories = _mapper.Map<List<Category>>(await _categoryService.Search(category));

            if (categories == null || categories.Count == 0) return NotFound();

            return Ok(categories);
        }
    }
}
