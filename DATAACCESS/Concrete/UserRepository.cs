using Dapper;
using DATAACCESS.Abstract;
using ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATAACCESS.Concrete
{
    public class UserRepository : IUserRepository
    {
        private SqlConnection SqlConnection()
        {
            return new SqlConnection("Server=.;Database=UsingDapperWithApi;uid=yusuf;pwd=123");
        }
        private IDbConnection CreateConnection()
        {
            var conn = SqlConnection();
            conn.Open();
            return conn;
        }
        public void DeleteUser(Guid id)
        {
            using (IDbConnection conn = CreateConnection())
            {
                conn.Execute("DeleteUsers", new { Id = id }, commandType: CommandType.StoredProcedure);
                conn.Close();
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (IDbConnection conn = CreateConnection())
            {
                IEnumerable<User> users = conn.Query<User>("SelectUsers", commandType: CommandType.StoredProcedure);
                conn.Close();
                return users;
            }
        }

        public User GetById(Guid id)
        {
            using (IDbConnection conn = CreateConnection())
            {
                User product = conn.QueryFirstOrDefault<User>("GetByIdForUsers", new { Id = id }, commandType: CommandType.StoredProcedure);
                conn.Close();
                return product;
            }
        }

        public void InsertUser(User user)
        {
            using (IDbConnection conn = CreateConnection())
            {
                conn.Execute("InsertUsers", new User
                {
                    Id = user.Id.ToString(),
                    Name = user.Name,
                    Surname = user.Surname,
                    Username = user.Username,
                    Age = user.Age,
                    Password = user.Password,
                }, commandType: CommandType.StoredProcedure);
                conn.Close();
            }
        }

        public void UpdateUser(User user)
        {
            using (IDbConnection conn = CreateConnection())
            {
                if (user != null)
                {
                    conn.Execute("UpdateUsers", new User
                    {
                        Id = user.Id.ToString(),
                        Name = user.Name,
                        Surname = user.Surname,
                        Username = user.Username,
                        Age = user.Age,
                        Password = user.Password,
                    }, commandType: CommandType.StoredProcedure);
                    conn.Close();
                }
                else
                {
                    throw new Exception("Üye bulunamamaktadır");
                }
            }
        }
    }
}
