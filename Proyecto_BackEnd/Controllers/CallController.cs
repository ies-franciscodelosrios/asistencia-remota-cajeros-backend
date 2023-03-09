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
        public CallModel insert([FromBody] CallModel c)
        {
            var c2=_call.Insert(c);
            List<CallModel> list = _call.GetAllByEstado0();
            sendMessage(list);
            return c2;

        }
        [NonAction]
        public void sendMessage(List<CallModel> data)
        {
            _hub.Clients.All.SendAsync("TransferChartData", data);
        }

        [HttpGet("GetAllByEstado0")]
        public List<CallModel> GetAllByEstado0()
        {
            return _call.GetAllByEstado0();
        }

        [HttpGet("GetAll")]
        public List<CallModel> GetAll()
        {
            return _call.GetAll();
        }

        [HttpPut("Update/{id}")]
        public void Update(int id, [FromBody] CallModel c)
        {
            _call.Update(id, c);
            List<CallModel> list = _call.GetAllByEstado0();
            sendMessage(list);
        }

        [HttpGet("get/{id}")]
        public CallModel CallModelGet(int id)
        {
            return _call.Get(id);
        }

        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
            _call.Delete(id);
            List<CallModel> list = _call.GetAllByEstado0();
            sendMessage(list);
        }
        [HttpDelete("DeleteAll")]
        public void DeleteAll()
        {
            _call.DeleteAll();
        }

    }
}
