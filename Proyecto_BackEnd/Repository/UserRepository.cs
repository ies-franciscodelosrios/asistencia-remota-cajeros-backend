using Microsoft.EntityFrameworkCore;
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

        //Método para insertar un usuario
        public void Insert(UserModel u) {
            try
            {
                _dbContext.Users.Add(u);
                _dbContext.SaveChanges();
                Console.WriteLine("Usuario guardado exitosamente.");
            }
            catch (DbUpdateException ex)
            {
                // Manejar excepciones específicas de Entity Framework
                Console.WriteLine("Error al guardar el Usuario en la base de datos: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones no esperadas
                Console.WriteLine("Error inesperado al guardar el Usuario: " + ex.Message);
            }
        }

        //Método para actualizar un usuario
        public void Update(int id, int c)
        {
            try
            {
                UserModel aux = _dbContext.Users.FirstOrDefault(p => p.id == id);
                if (aux != null)
                {
                    aux.note = c;
                    _dbContext.SaveChanges();
                }
            } catch(DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Método que devuelve toda la lista de usuarios en la base de datos
        public List<UserModel>? GetAll()
        {
            try
            {
                return _dbContext.Users.ToList();
            }
            catch(DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //Método que a través del usuario y la contraseña del usuario busca en la base de datos si existe para logearse
        public UserModel? get(string username, string password)
        {
            try
            {
                var aux = new UserModel();
                aux = _dbContext.Users.FirstOrDefault(u => u.username == username && u.password == password);
                if (aux != null)
                {
                    return aux;
                }
                else
                {
                    Console.WriteLine("No se ha podido encontrar el usuario");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //Método para borrar un usuario de la base de datos
        public void Delete(int id)
        {
            try
            {
                _dbContext.Users.Remove(_dbContext.Users.FirstOrDefault(u => u.id == id));
                _dbContext.SaveChanges();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
