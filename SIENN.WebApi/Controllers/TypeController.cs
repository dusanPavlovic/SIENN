using Microsoft.AspNetCore.Mvc;
using SIENN.Services.Models;
using SIENN.Services.Services;

namespace SIENN.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Type")]
    public class TypeController : Controller
    {
        private readonly IGenericService<TypeDto> _service;

        public TypeController(IGenericService<TypeDto> service)
        {
            _service = service;
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
        public IActionResult Post([FromBody] TypeDto type)
        {
            _service.Add(type);

            return CreatedAtAction("Get", "Type", new { code = type.Code }, type);
        }

        [HttpDelete("{code}")]
        public IActionResult Delete([FromRoute] int code)
        {
            _service.Remove(code);

            return NoContent();
        }

        [HttpPut]
        public IActionResult Put([FromBody] TypeDto type)
        {
            _service.Edit(type);

            return Ok();
        }
    }
}