using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace PickBazar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categoryList=await _categoryService.GetAll();

            if (categoryList == null)
            {
                return BadRequest(new { status = 400, message = "error" });
            }
            return Ok(categoryList);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            var category = _categoryService.GetById(id);
            if (category == null || category.Id != id)
            {
                return null;
            }
            return category;
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] CategoryDTO category)
        {
                _categoryService.Add(category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CategoryDTO category)
        {
            _categoryService.Update(id,category);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryService.Delete(id);
        }
    }

    
}
