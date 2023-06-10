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

        //Método para insertar una llamada en la base de datos
        public CallModel? Insert(CallModel c)
        {
            try
            {
                CallModel cold = _dbContext.Calls.FirstOrDefault(p => p.CajeroId == c.CajeroId && p.estado == 0);
                if (cold != null)
                {
                    Delete(cold.id);
                }
                _dbContext.Calls.Add(c);
                _dbContext.SaveChanges();
                return c;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
            
        //Método para devolver todas las llamadas que tengan el estado 0 = "Esperando ser atendidos"
        public List<CallModel>? GetAllByEstado0()
        {
            try
            {
                List<CallModel> aux = _dbContext.Calls.ToList();
                return aux.OrderByDescending(x => x.date)
                    .Where(x => x.estado == Estado.Calling)
                    .Where(x => x.UserId == null)
                    .ToList();
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //Devuelve todas las llamadas que han sido atendidas por un usuario en concreto pasándole su ID
        public List<CallModel>? GetAllByUser(int idUser)
        {
            try
            {
                List<CallModel> aux = _dbContext.Calls.ToList();
                return aux.OrderByDescending(x => x.date)
                    .Where(x => x.UserId == idUser)
                    .Where(x => x.estado == Estado.Finalized).ToList();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //Devuelve todas las llamadas de la base de datos
        public List<CallModel>? GetAll()
        {
            try
            {
                List<CallModel> aux = _dbContext.Calls.ToList();
                return aux.OrderByDescending(x => x.date).ToList();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //Actualiza una llamada en la base de datos
        public void Update (int id, CallModel c)
        {
            try
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
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Actualiza una llamada en la base de datos pasándole el rating, además traemos todas las llamadas atendidas por un usuario en concreto
        //sumamos todos los rating y los dividimos para saber el rating medio del usuario
        public void UpdateRating(int id, CallModel c, int idUser)
        {
            try
            {
                CallModel aux = _dbContext.Calls.FirstOrDefault(p => p.id == id);
                int rating = 0;
                if (aux != null)
                {
                    aux.rating = c.rating;
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
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Devuelve la llamada pasándole su ID
        public CallModel? get(int id)
        {
            try
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
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //Elimina una llamada de la base de datos
        public void Delete(int id)
        {
            try
            {
                _dbContext.Calls.Remove(_dbContext.Calls.FirstOrDefault(u => u.id == id));
                _dbContext.SaveChanges();
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Devuelve el número de cola en el que nos encontramos
        public int GetQueueNumber(int id)
        {
            try
            {
                var aux = new CallModel();
                aux = _dbContext.Calls.FirstOrDefault(u => u.id == id);
                if (aux != null)
                {
                    var queueCalls = _dbContext.Calls.Where(call => call.estado == 0 && call.date <= aux.date);
                    return queueCalls.Count();
                }
                else
                {
                    return 0;
                }
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        //Devuelve la duración estimada que tenemos que esperar para ser atendidos cuando solicitamos una llamada
        public decimal GetDurationEstimated()
        {
            try
            {
                var llamadasEstado2 = _dbContext.Calls.Where(call => call.estado == Estado.Finalized);
                var sumaDuraciones = llamadasEstado2.Sum(l => l.duration);
                var totalLlamadasEstado2 = llamadasEstado2.Count();
                decimal tiempoEstimadoEspera = totalLlamadasEstado2 > 0 ? sumaDuraciones / totalLlamadasEstado2 : 0;
                return tiempoEstimadoEspera;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        //Borra todas las llamadas de la base de datos
        public void DeleteAll()
        {
            try
            {
                var Calls = _dbContext.Calls;
                _dbContext.Calls.RemoveRange(Calls);
                _dbContext.SaveChanges();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
