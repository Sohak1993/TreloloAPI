using DAL.Models.List;
using DAL.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IListRepo
    {
        public IEnumerable<TaskList> GetAll();
        public TaskList GetById(int id);
        public bool Create(NewList list);
        public bool Delete(int id);
        public bool Update(TaskList list);
        public IEnumerable<TaskList> GetByProject(int idProject);
    }
}
