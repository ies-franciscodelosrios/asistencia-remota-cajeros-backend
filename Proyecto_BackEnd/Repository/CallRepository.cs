using Proyecto_BackEnd.Context;
using Proyecto_BackEnd.Model;
using System.Collections.Generic;

namespace Proyecto_BackEnd.Repository
{
    public class CallRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public CallRepository(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
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
                aux.CajeroId = c.CajeroId;
                aux.UserId = c.UserId;
                _dbContext.SaveChanges();
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

        public void DeleteAll()
        {
            var Calls = _dbContext.Calls;
            _dbContext.Calls.RemoveRange(Calls);
            _dbContext.SaveChanges();
        }
    }
}
