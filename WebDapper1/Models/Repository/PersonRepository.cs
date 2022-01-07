using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.Reflection;
using WebDapper1.Models.DomainModel;

namespace WebDapper1.Models.Repository
{
    public interface IPersonRepository
    {
        void Create(PersonModel Model);
        void Delete(int id);

        IEnumerable<PersonModel> getAll();

        PersonModel GetId(int id);

        void Update(int id,PersonModel model);

    }

    public class PersonRepository : IPersonRepository
    {
        readonly private string connection = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        private string Table= "PersonTable";
        private string Table1 = "Pers";

        public void Create(PersonModel Model)
        {
            using (var conn = new SqlConnection(connection))
            {
                var sql = $"INSERT INTO {Table} (Name,Email,Address) VALUES(@Name,@Email,@Address)";
                conn.Execute(sql,Model);
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SqlConnection(connection))
            {
                var sql = $"Delete From {Table} Where id = @id";
                conn.Execute(sql, new { id});
            }
        }

        public IEnumerable<PersonModel> getAll()
        {
            IEnumerable<PersonModel> result;
            using (var conn = new SqlConnection(connection))
            {
                var sql = $"select * From {Table}";
                result=conn.Query<PersonModel>(sql);
            }
            return result;
        }

        public PersonModel GetId(int id)
        {
        
            using (var conn = new SqlConnection(connection))
            {
                var sql = $"select * from {Table} Where id = @id";
                return conn.QuerySingleOrDefault<PersonModel>(sql, new { id});
            }
        }

        public void Update(int id, PersonModel model)
        {
            using (var conn = new SqlConnection(connection))
            {
                var sql = $"UPDATE {Table} SET Name=@Name, Email=@Email, Address=@Address where id = @id";
                conn.Execute(sql, model);
            }
        }


        public Login Login(Login model)
        {
            using (var conn = new SqlConnection(connection))
            {
                var sql = $"select * from Login where Account=@Account AND Password=@Password";
                return conn.QuerySingleOrDefault<Login>(sql,model);
            }
        }


    }
}