using BLL.Interfaces;
using DALM = DAL.Models.User;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Mapper;
using BLL.Models.User;

namespace BLL.Services
{
    public class UserService : ObjectMapper, IUserService
    {

        private readonly IUserRepo _userRepo;
     
        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public User Login(string email, string password)
        {
            return MapModel<User, DALM.User>(_userRepo.Login(email, password));
        }

        public bool Create(NewUser user)
        {
            return _userRepo.Create(MapModel<DALM.NewUser, NewUser>(user));
        }

        public bool Delete(int id)
        {
            return _userRepo.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepo.GetAll()
                .Select(u => MapModel<User, DALM.User>(u));
        }

        public User GetById(int id)
        {
            return MapModel<User, DALM.User>(_userRepo.GetById(id));
        }

        public bool Update(NewUser user)
        {
            throw new NotImplementedException();
        }
    }
}
