using DAL.Interfaces;
using DAL.Models.User;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;
using ToolBox.Models;

namespace DAL.Repositories
{
    public class UserRepo : Connection, IUserRepo
    {
        private string? _connectionString;
        public UserRepo(IConfiguration config) : base(config)
        {
        }

        public bool Create(NewUser user)
        {
            Command cmd = new Command("RegisterUser", true);

            cmd.AddParameter("email", user.Email);
            cmd.AddParameter("Password", user.Password);

            return ExecuteNonQuery(cmd) == 1;
        }

        public bool Delete(int id)
        {
            Command cmd = new Command("DELETE FROM USERS WHERE Id = @id");

            cmd.AddParameter("id", id);

            return ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<User> GetAll()
        {
            Command cmd = new Command("SELECT Id, Email, IsActive, CreationDate FROM Users WHERE IsActive = 1");

            return ExecuteReader<User>(cmd);
        }

        public User GetById(int id)
        {
            Command cmd = new Command("SELECT Id, Email, IsActive, CreationDate FROM Users WHERE Id = @id AND IsActive = 1");

            cmd.AddParameter("id", id);

            return ExecuteReader<User>(cmd).First();
        }

        public bool Update(NewUser user)
        {
            throw new NotImplementedException();
        }

    }
}
