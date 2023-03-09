using Microsoft.AspNetCore.SignalR;
using Microsoft.OpenApi.Any;
using Proyecto_BackEnd.Repository;
using Proyecto_BackEnd.Service;
using System.Diagnostics;

namespace Proyecto_BackEnd.HubConfig
{
    public class CallHub :Hub
    {
        private readonly CallService callService;

        public CallHub(CallService callService)
        {
            this.callService = callService;
            Console.WriteLine("Hub Creado");
        }

        public override async Task OnConnectedAsync()
        {
            Console.WriteLine("Cliente Conectado");
            //podemos devolver la lista
           await this.Clients.All.SendAsync("TransferChartData", this.callService.GetAllByEstado0());
        }
        public override async Task OnDisconnectedAsync(Exception? ex)
        {
            Console.WriteLine("Cliente Desconectado");
        }
    }
}
