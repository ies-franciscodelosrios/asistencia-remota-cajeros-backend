using Proyecto_BackEnd.Model;
using Proyecto_BackEnd.Repository;

namespace Proyecto_BackEnd.Service
{
    public class CallService
    {
        private readonly CallRepository _repository;

        public CallService(CallRepository repository)
        {
            _repository = repository;
        }

        public CallModel Insert(CallModel c)
        {
            return _repository.Insert(c);
        }

        public List<CallModel> GetAllByEstado0()
        {
            return _repository.GetAllByEstado0();
        }

        public List<CallModel> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(int id, CallModel c)
        {
            _repository.Update(id, c);
        }

        public CallModel Get(int id)
        {
           return _repository.get(id);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void DeleteAll()
        {
            _repository.DeleteAll();
        }
    }
}
