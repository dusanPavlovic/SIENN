using Microsoft.AspNetCore.Mvc;
using SIENN.Services.Models;
using SIENN.Services.Services;

namespace SIENN.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Unit")]
    public class UnitController : Controller
    {
        private readonly IGenericService<UnitDto> _service;

        public UnitController(IGenericService<UnitDto> service)
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
        public IActionResult Post([FromBody] UnitDto unit)
        {
            _service.Add(unit);
            return CreatedAtAction("Get", "Unit", new { code = unit.Code }, unit);
        }

        [HttpDelete("{code}")]
        public IActionResult Delete([FromRoute]int code)
        {
            _service.Remove(code);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put([FromBody] UnitDto unit)
        {
            _service.Edit(unit);
            return Ok();
        }
    }
}