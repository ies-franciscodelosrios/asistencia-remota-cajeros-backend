using Microsoft.EntityFrameworkCore;
using Proyecto_BackEnd.Context;
using Proyecto_BackEnd.Model;

namespace Proyecto_BackEnd.Repository
{
    public class CajeroRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public CajeroRepository(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }

        public void Insert(CajeroModel c)
        {
            try
            {
                _dbContext.Cashiers.Add(c);
                _dbContext.SaveChanges();
                Console.WriteLine("Cajero guardado exitosamente.");
            }
            catch (DbUpdateException ex)
            {
                // Manejar excepciones específicas de Entity Framework
                Console.WriteLine("Error al guardar el Cajero en la base de datos: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones no esperadas
                Console.WriteLine("Error inesperado al guardar el cajero: " + ex.Message);
            }
        }

        //Inserta un cajero en la base de datos
        public List<CajeroModel> GetAll()
        {
            try
            {
                // Lógica para obtener los Cashiers de la base de datos
                return _dbContext.Cashiers.ToList();
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir
                Console.WriteLine("Error al obtener los Cashiers: " + ex.Message);
                return new List<CajeroModel>(); // Devuelve una lista vacía en caso de error
            }
        }

        //Devuelve el cajero pasándole una IP
        public CajeroModel? GetByIp(string ip)
        {
            try
            {
                var aux = new CajeroModel();
                aux = _dbContext.Cashiers.FirstOrDefault(u => u.ip == ip);
                if (aux != null)
                {
                    return aux;
                }
                else
                {
                    Console.WriteLine("El cajero no existe");
                    return null;
                }
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        //Elimina un cajero de la base de datos
        public void Delete(int id)
        {
            try
            {
                _dbContext.Cashiers.Remove(_dbContext.Cashiers.FirstOrDefault(u => u.id == id));
                _dbContext.SaveChanges();
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Devuelve un cajero pasándole su ID
        public CajeroModel? Get(int id)
        {
            try
            {
                var aux = new CajeroModel();
                aux = _dbContext.Cashiers.FirstOrDefault(u => u.id == id);
                if (aux != null)
                {
                    return aux;
                }
                else
                {
                    Console.WriteLine("No se ha podido encontrar el cajero");
                    return null;
                }
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
