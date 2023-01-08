using BLL.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<User> GetAll();
        public User GetById(int id);
        public bool Create(NewUser user);
        public bool Delete(int id);
        public bool Update(NewUser user);
    }
}
