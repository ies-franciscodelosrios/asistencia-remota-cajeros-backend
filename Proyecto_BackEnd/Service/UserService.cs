using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using Proyecto_BackEnd.Context;
using Proyecto_BackEnd.Model;
using Proyecto_BackEnd.Repository;
using System.Configuration;
using System.Data;

namespace Proyecto_BackEnd.Service
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public void update (int id, int note)
        {
            _repository.Update(id, note);
        }

        public void Insert(UserModel u)
        {
            _repository.Insert(u);

        }

        public UserModel get(string username, string password)
        {
            return _repository.get(username, password);
        }
        public List<UserModel> GetAll()
        {
            return _repository.GetAll();
        }

        public void delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
