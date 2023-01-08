using BLL.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProjectService
    {
        public IEnumerable<Project> GetAll();
        public Project GetById(int id);
        public bool Create(NewProject project);
        public bool Delete(int id);
        public bool Update(Project project);
        public IEnumerable<Project> GetByUser(int idUser);
    }
}
