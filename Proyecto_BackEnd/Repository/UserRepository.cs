using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Proyecto_BackEnd.Context;
using Proyecto_BackEnd.Model;

namespace Proyecto_BackEnd.Repository
{
    public class UserRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public UserRepository(ApplicationDBContext applicationDBContext) {
            _dbContext = applicationDBContext;
        }

        public void Insert(UserModel u) {
            _dbContext.Users.Add(u);
            _dbContext.SaveChanges();
        }

        public List<UserModel> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public UserModel get(string username, string password)
        {
            var aux = new UserModel();
            aux = _dbContext.Users.FirstOrDefault(u => u.username == username && u.password == password);
            if(aux != null)
            {
                return aux;
            } else
            {
                return null;
            }
        }

        public void Delete(int id)
        {
            _dbContext.Users.Remove(_dbContext.Users.FirstOrDefault(u => u.id == id));
            _dbContext.SaveChanges();
        }
    }
}
