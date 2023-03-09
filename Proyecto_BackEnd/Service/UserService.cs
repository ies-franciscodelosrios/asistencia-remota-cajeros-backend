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

        public void Insert(UserModel u)
        {
            _repository.Insert(u);

        }

        public UserModel get(string username, string password)
        {
            return _repository.get(username, password);
        }

        //public string GetAll()
        //{
        //    OracleConnection con = new OracleConnection(_configuration.GetConnectionString("DefaultConnection").ToString());
        //    OracleDataAdapter da = new OracleDataAdapter("SELECT * FROM USERS", con);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    List<UserModel> list = new List<UserModel>();
        //    if (dt.Rows.Count > 0)
        //    {

        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            UserModel model = new UserModel();
        //            model.id = Convert.ToInt32(dt.Rows[i][""]);
        //            model.username = Convert.ToString(dt.Rows[i][""]);
        //            model.password = Convert.ToString(dt.Rows[i][""]);
        //            list.Add(model);
        //        }
        //    }
        //    if (list.Count > 0)
        //    {
        //        return JsonConvert.SerializeObject(list);
        //    }
        //    else
        //    {
        //        return JsonConvert.SerializeObject(null);
        //    }
        //}
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
