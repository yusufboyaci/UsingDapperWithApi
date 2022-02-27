using DATAACCESS.Abstract;
using ENTITIES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            _productRepository.DeleteProduct(id);
            return NoContent();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productRepository.GetAll()); 
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            Product product = _productRepository.GetById(id);
            return Ok(product);
        }
        [HttpPost]
        public IActionResult Insert(Product product)
        {
           _productRepository.InsertProduct(product);
            return NoContent();
        }
        [HttpPut]
        public IActionResult Update(Product product)
        {
            _productRepository.UpdateProduct(product);
            return NoContent();
        }
    }
}
