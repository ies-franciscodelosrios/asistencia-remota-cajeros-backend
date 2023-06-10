using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.OpenApi.Any;
using Proyecto_BackEnd.HubConfig;
using Proyecto_BackEnd.Model;
using Proyecto_BackEnd.Service;

namespace Proyecto_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallController : ControllerBase
    {
        public readonly CallService _call;
        private readonly IHubContext<CallHub> _hub;
        public CallController(CallService callService, IHubContext<CallHub> hub)
        {
            _call = callService;
            _hub = hub;
        }

        [HttpPost]
        public IActionResult insert([FromBody] CallModel c)
        {
            try
            {
                if (c != null)
                {
                    _call.Insert(c);
                    List<CallModel> list = _call.GetAllByEstado0();
                    sendMessage(list);
                    return Ok(c);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error al insertar la llamada.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar la solicitud: " + ex.Message);
            }

        }

        [NonAction]
        public void sendMessage(List<CallModel> data)
        {
            _hub.Clients.All.SendAsync("TransferChartData", data);
        }

        [HttpGet("GetAllByEstado0")]
        public IActionResult GetAllByEstado0()
        {
            try
            {
                List<CallModel> calls = _call.GetAllByEstado0();
                return Ok(calls);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener las llamadas: " + ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                List<CallModel> calls = _call.GetAll();
                return Ok(calls);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener las llamadas: " + ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] CallModel c)
        {
            try
            {
                if (c == null)
                {
                    return BadRequest("El objeto Call es nulo.");
                }
                _call.Update(id, c);
                List<CallModel> list = _call.GetAllByEstado0();
                sendMessage(list);
                return Ok("Llamada actualizada exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar la llamada: " + ex.Message);
            }
        }

        [HttpPut("UpdateRating/{id}")]
        public IActionResult UpdateRating(int id, [FromBody] CallModel c, int idUser)
        {
            try
            {
                if (c == null)
                {
                    return BadRequest("El objeto Call es nulo.");
                }
                _call.UpdateRating(id, c, idUser);
                return Ok("Calificación de llamada actualizada exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar la calificación de la llamada: " + ex.Message);
            }
        }

        [HttpGet("get/{id}")]
        public IActionResult CallModelGet(int id)
        {
            try
            {
                CallModel call = _call.Get(id);
                if (call != null)
                {
                    return Ok(call);
                }
                else
                {
                    return NotFound("No se encontró la llamada con el ID especificado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener la llamada: " + ex.Message);
            }
        }

        [HttpGet("GetAllByUser/{id}")]
        public IActionResult GetAllByUser(int id)
        {
            try
            {
                List<CallModel> calls = _call.GetAllByUser(id);
                if (calls != null && calls.Count > 0)
                {
                    return Ok(calls);
                }
                else
                {
                    return NotFound("No se encontraron llamadas asociadas al usuario con el ID especificado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener las llamadas del usuario: " + ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _call.Delete(id);
                List<CallModel> list = _call.GetAllByEstado0();
                sendMessage(list);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar la llamada: " + ex.Message);
            }
        }

        [HttpDelete("DeleteAll")]
        public IActionResult DeleteAll()
        {
            try
            {
                _call.DeleteAll();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar todas las llamadas: " + ex.Message);
            }
        }

        [HttpGet("QueueNumber/{id}")]
        public IActionResult GetQueueNumber(int id)
        {
            try
            {
                int queueNumber = _call.GetQueueNumber(id);
                if (queueNumber != -1)
                {
                    return Ok(queueNumber);
                }
                else
                {
                    return NotFound("No se encontró la llamada con el ID especificado o no tiene un número de cola válido.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el número de cola de la llamada: " + ex.Message);
            }
        }

        [HttpGet("DurationEstimated")]
        public IActionResult GetDurationEstimated()
        {
            try
            {
                decimal durationEstimated = _call.GetDurationEstimated();
                if (durationEstimated >= 0)
                {
                    return Ok(durationEstimated);
                }
                else
                {
                    return NotFound("No se pudo obtener la duración estimada de la llamada.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener la duración estimada de la llamada: " + ex.Message);
            }
        }
    }
}
