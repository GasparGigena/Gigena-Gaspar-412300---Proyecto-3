using BibliotecaBack.Entities;
using BibliotecaBack.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace proyecto2WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _facturaService;

        public FacturaController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_facturaService.GetAll());
        }
        public IActionResult Post([FromBody] Factura factura)
        {
            return Ok(_facturaService.Save(factura));
        }
        public IActionResult Put([FromQuery]int id, [FromBody] Factura factura)
        {
            return Ok(_facturaService.Update(factura, id));
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery]int id)
        {
            return Ok(_facturaService.Delete(id));
        }
    }
}
