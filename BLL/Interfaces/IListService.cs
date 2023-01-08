using BLL.Models.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IListService
    {
        public IEnumerable<TaskList> GetAll();
        public TaskList GetById(int id);
        public bool Create(NewList list);
        public bool Delete(int id);
        public bool Update(TaskList list);
        public IEnumerable<TaskList> GetByProject(int idProject);
    }
}
