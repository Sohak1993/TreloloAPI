using BLL.Models.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITaskService
    {
        public IEnumerable<FullTask> GetAll();
        public FullTask GetById(int id);
        public bool Create(NewTask list);
        public bool Delete(int id);
        public bool Update(FullTask list);
        public IEnumerable<FullTask> GetByList(int idList);
    }
}
