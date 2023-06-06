using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Proyecto_BackEnd.Context;
using Proyecto_BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace Proyecto_BackEnd.Repository
{
    public class CallRepository
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly UserRepository _repository;

        public CallRepository(ApplicationDBContext applicationDBContext, UserRepository repository)
        {
            _dbContext = applicationDBContext;
            _repository = repository;
        }

        public CallModel Insert(CallModel c)
        {
            CallModel cold = _dbContext.Calls.FirstOrDefault(p => p.CajeroId == c.CajeroId && p.estado == 0);
            if(cold != null)
            {
                Delete(cold.id);
            }
            _dbContext.Calls.Add(c);
            _dbContext.SaveChanges();
            return c;
        }
            

        public List<CallModel> GetAllByEstado0()
        {
            List<CallModel> aux = _dbContext.Calls.ToList();
            return aux.OrderByDescending(x => x.date)
                .Where(x => x.estado == Estado.Calling)
                .Where(x => x.UserId == null)
                .ToList();
        }

        public List<CallModel> GetAllByUser(int idUser)
        {
            List<CallModel> aux = _dbContext.Calls.ToList();
            return aux.OrderByDescending(x => x.date)
                .Where(x=> x.UserId == idUser)
                .Where(x => x.estado == Estado.Finalized).ToList();
        }

        public List<CallModel> GetAll()
        {
            List<CallModel> aux = _dbContext.Calls.ToList();
            return aux.OrderByDescending(x => x.date).ToList();
        }

        public void Update (int id, CallModel c)
        {
            CallModel aux = _dbContext.Calls.FirstOrDefault(p => p.id == id);
            if (aux != null)
            {
                aux.p2p = c.p2p;
                aux.estado = c.estado;
                aux.date = c.date;
                aux.duration = c.duration;
                aux.CajeroId = c.CajeroId;
                aux.UserId = c.UserId;
                _dbContext.SaveChanges();
            }
        }

        public void UpdateRating(int id, CallModel c, int idUser)
        {
            CallModel aux = _dbContext.Calls.FirstOrDefault(p => p.id == id);
            int rating = 0;
            if (aux != null)
            {
                aux.rating= c.rating;
                _dbContext.SaveChanges();
                rating = (int)aux.rating;
                if (c.rating != 0)
                {
                    List<CallModel> list = GetAllByUser(idUser);
                    var count = list.Count();
                    for (int i = 0; i < count; i++)
                    {
                        var contador = list[i];
                        rating += (int)contador.rating;
                    }
                    int resultado = rating;
                    int r = resultado / count;
                    _repository.Update(idUser, r);
                }
            }
        }

        public CallModel get(int id)
        {
            var aux = new CallModel();
            aux = _dbContext.Calls.FirstOrDefault(u => u.id == id);
            if (aux != null)
            {
                return aux;
            }
            else
            {
                return null;
            }
        }

        public void Delete(int id)
        {
            _dbContext.Calls.Remove(_dbContext.Calls.FirstOrDefault(u => u.id == id));
            _dbContext.SaveChanges();
        }

        public int GetQueueNumber(int id)
        {
            var aux = new CallModel();
            aux = _dbContext.Calls.FirstOrDefault(u => u.id == id);
            if (aux != null)
            {
                var queueCalls = _dbContext.Calls.Where(call => call.estado == 0 && call.date <= aux.date);
                return queueCalls.Count();
            } else
            {
                return 0;
            }
  
        }

        public decimal GetDurationEstimated()
        {
            var llamadasEstado2 = _dbContext.Calls.Where(call => call.estado == Estado.Finalized);
            var sumaDuraciones = llamadasEstado2.Sum(l => l.duration);
            var totalLlamadasEstado2 = llamadasEstado2.Count();
            decimal tiempoEstimadoEspera = totalLlamadasEstado2 > 0 ? sumaDuraciones / totalLlamadasEstado2 : 0;
            return tiempoEstimadoEspera;
        }

        public void DeleteAll()
        {
            var Calls = _dbContext.Calls;
            _dbContext.Calls.RemoveRange(Calls);
            _dbContext.SaveChanges();
        }
    }
}
