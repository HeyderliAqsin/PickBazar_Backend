using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace PickBazar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productList = await _productService.GetAll();

            if (productList ==null)
            {
                return BadRequest(new { status = 400, message = "error" });
            };

            var _mapperProduct = _mapper.Map<List<Product>, List<ProductListDTO>>(productList);


            return Ok(new { _mapperProduct });

        }

        //GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductDTO GetById(int? id)
        {
            var product = _productService.GetById(id);
            if (product ==null || product.Id!=id)
            {
                return null;
            }
            
            var _mapperProduct = _mapper.Map<ProductDTO>(product);

            return _mapperProduct;
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] ProductDTO product)
        {
            _productService.Add(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductDTO pro)
        {
            _productService.Update(id, pro);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productService.Delete(id);
        }
    }
}
