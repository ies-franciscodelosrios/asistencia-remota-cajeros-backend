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
        public List<UserModel> GetUsers()
        {
            return _userService.GetAll();
            
        }

        [HttpPost]
        public void Insert([FromBody]UserModel user)
        {
            _userService.Insert(user);
        }

        [HttpGet("get/{username}/{password}")]
        public UserModel GetUser(string username, string password)
        {
            return _userService.get(username, password);
        }

        [HttpDelete("Delete/{id}")]
        public void DeleteUser(int id)
        {
            _userService.delete(id);
        }
    }
}
