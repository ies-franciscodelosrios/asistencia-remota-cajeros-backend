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
        public List<CajeroModel> GetAll()
        {
            return _cajeroService.GetAll();
        }

        [HttpPost]
        public void Insert([FromBody] CajeroModel model)
        {
            _cajeroService.Insert(model);
        }

        [HttpGet("get/{id}")]
        public CajeroModel Get(int id)
        {
            return _cajeroService.GetById(id);
        }
    }
}
