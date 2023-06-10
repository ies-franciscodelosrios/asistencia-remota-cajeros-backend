using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_BackEnd.Model;
using Proyecto_BackEnd.Service;

namespace Proyecto_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CajeroController : ControllerBase
    {
        public readonly CajeroService _cajeroService;
        public CajeroController(CajeroService cajeroService)
        {
            _cajeroService = cajeroService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                List<CajeroModel> cajeros = _cajeroService.GetAll();
                if (cajeros != null && cajeros.Count > 0)
                {
                    return Ok(cajeros);
                }
                else
                {
                    return NotFound("No se encontraron cajeros.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los cajeros: " + ex.Message);
            }
        }

        [HttpGet("getByIp/{ip}")]
        public IActionResult GetByIp(string ip)
        {
            try
            {
                CajeroModel cajero = _cajeroService.GetByIp(ip);
                if (cajero != null)
                {
                    return Ok(cajero);
                }
                else
                {
                    return NotFound("No se encontró el cajero con la IP especificada.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el cajero: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody] CajeroModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("El objeto Cajero es nulo.");
                }
                _cajeroService.Insert(model);
                return Ok("Cajero insertado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al insertar el cajero: " + ex.Message);
            }
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                CajeroModel cajero = _cajeroService.GetById(id);
                if (cajero != null)
                {
                    return Ok(cajero);
                }
                else
                {
                    return NotFound("No se encontró el cajero con el ID especificado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el cajero: " + ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _cajeroService.Delete(id);
                return Ok("Cajero eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el cajero: " + ex.Message);
            }
        }
    }
}
