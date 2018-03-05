using Microsoft.AspNetCore.Mvc;
using SIENN.Services.Models;
using SIENN.Services.Services;

namespace SIENN.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        private readonly IGenericService<CategoryDto> _service;

        public CategoryController(IGenericService<CategoryDto> service)
        {
            _service = service;
        }

        [HttpGet("{code}")]
        public IActionResult Get([FromRoute]int code)
        {
            return Ok(_service.Get(code));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody]CategoryDto category)
        {
            _service.Add(category);
            return CreatedAtAction("Get", "Category", new { code = category.Code }, category);
        }

        [HttpPut]
        public IActionResult Put([FromBody] CategoryDto category)
        {
            _service.Edit(category);
            return Ok();
        }

        [HttpDelete("{code}")]
        public IActionResult Delete(int code)
        {
            _service.Remove(code);
            return NoContent();
        }
    }
}