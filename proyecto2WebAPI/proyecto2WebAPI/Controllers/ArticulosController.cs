using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;
using proyecto_Practica02_.Entities;

namespace proyecto_Practica02_
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private IArticuloManager service;

        public ArticulosController()
        {
            service = new ArticuloManager();
        }

        [HttpGet("articulos")]
        public IActionResult Get()
        {
            return Ok(service.GetArticulos());
        }

        [HttpPost]
        public IActionResult Post([FromBody]Articulo articulo)
        {
            try
            {
                if(articulo == null)
                {
                    return BadRequest("El articulo es incorrecto");
                }
                if (service.AgregarArticulo(articulo))
                    return Ok("Articulo guardado exitosamente");
                else
                    return StatusCode(500, "Hubo un error al registrar el articulo");
            }
            catch (Exception)
            {
                return StatusCode(500, "Hubo un error inesperado, INTENTAR DE NUEVO!!!");
            }
        }

        [HttpPut]
        public IActionResult Update(Articulo articulo)
        {
            try
            {
                if (service.EditarArticulo(articulo))
                {
                    return Ok("Se actualizo con exito el articulo");
                }
                else
                {
                    return BadRequest("No se pudo actualizar el articulo");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error inesperado, intente de nuevo!");
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = service.BorrarArticulo(id);
            return Ok("El articulo fue eliminado exitosamente");
        }
    }
}
