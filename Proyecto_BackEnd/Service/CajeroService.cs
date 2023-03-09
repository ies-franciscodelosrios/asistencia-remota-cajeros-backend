using Proyecto_BackEnd.Model;
using Proyecto_BackEnd.Repository;

namespace Proyecto_BackEnd.Service
{
    public class CajeroService
    {
        private readonly CajeroRepository _repository;

        public CajeroService(CajeroRepository repository)
        {
            _repository = repository;
        }

        public void Insert(CajeroModel c)
        {
            _repository.Insert(c);
        }

        public List<CajeroModel> GetAll()
        {
            return _repository.GetAll();
        }

        public CajeroModel GetById(int id)
        {
            return _repository.Get(id);
        }
    }
}
