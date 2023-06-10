using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using Proyecto_BackEnd.Context;
using Proyecto_BackEnd.Model;
using Proyecto_BackEnd.Repository;
using Proyecto_BackEnd.Service;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json.Serialization;

namespace Proyecto_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetUsers()
        {
            try
            {
                List<UserModel> users = _userService.GetAll();
                if (users != null && users.Count > 0)
                {
                    return Ok(users);
                }
                else
                {
                    return NotFound("No se encontraron usuarios.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los usuarios: " + ex.Message);
            }

        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] int note)
        {
            try
            {
                if (note < 0 || note > 5)
                {
                    return BadRequest("La nota debe estar entre 0 y 5.");
                }
                _userService.update(id, note);
                return Ok("Usuario actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el usuario: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody]UserModel user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("El objeto UserModel es nulo.");
                }
                _userService.Insert(user);
                return Ok("Usuario insertado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al insertar el usuario: " + ex.Message);
            }
        }

        [HttpGet("get/{username}/{password}")]
        public IActionResult GetUser(string username, string password)
        {
            try
            {
                UserModel user = _userService.get(username, password);
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound("No se encontró el usuario con las credenciales especificadas.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el usuario: " + ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.delete(id);
                return Ok("Usuario eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el usuario: " + ex.Message);
            }
        }
    }
}
