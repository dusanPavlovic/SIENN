using Microsoft.AspNetCore.Mvc;
using SIENN.Services.Models;
using SIENN.Services.Services;

namespace SIENN.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly IGenericService<ProductDto> _service;
        private readonly IProductService _productService;

        public ProductController(IGenericService<ProductDto> service, IProductService productService)
        {
            _service = service;
            _productService = productService;
        }

        [HttpGet("info/{code}")]
        public IActionResult GetInfo([FromRoute] int code)
        {
            return Ok(_productService.GetProductInfo(code));
        }

        [HttpGet("available")]
        public IActionResult GetAvailableProducts(int start, int count)
        {
            return Ok(_productService.GetAvailableProducts(start, count));
        }

        [HttpGet("filter")]
        public IActionResult GetFiltered(int? category, int? type, int? unit)
        {
            return Ok(_productService.GetFilteredProducts(category, type, unit));
        }

        [HttpGet("{code}")]
        public IActionResult Get([FromRoute] int code)
        {
            return Ok(_service.Get(code));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductDto product)
        {
            _service.Add(product);
            return CreatedAtAction("Get", "Product", new { code = product.Code }, product);
        }

        [HttpDelete("{code}")]
        public IActionResult Delete(int code)
        {
            _service.Remove(code);

            return NoContent();
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProductDto product)
        {
            _service.Edit(product);

            return Ok();
        }
    }
}