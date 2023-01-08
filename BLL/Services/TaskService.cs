using BLL.Interfaces;
using BLL.Models.Task;
using DAL.Interfaces;
using DALM = DAL.Models.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Mapper;
using BLL.Models.List;
using DAL.Repositories;

namespace BLL.Services
{
    public class TaskService : ObjectMapper, ITaskService
    {
        private readonly ITaskRepo _taskRepo;

        public TaskService(ITaskRepo taskRepo)
        {
            _taskRepo = taskRepo;   
        }

        public bool Create(NewTask task)
        {
            return _taskRepo.Create(MapModel<DALM.NewTask, NewTask>(task));
        }

        public bool Delete(int id)
        {
            return _taskRepo.Delete(id);
        }

        public IEnumerable<FullTask> GetAll()
        {
            return _taskRepo.GetAll()
              .Select(task => MapModel<FullTask, DALM.FullTask>(task));
        }

        public FullTask GetById(int id)
        {
            return MapModel<FullTask, DALM.FullTask>(_taskRepo.GetById(id));
        }

        public IEnumerable<FullTask> GetByList(int idList)
        {
            return _taskRepo.GetByList(idList)
            .Select(task => MapModel<FullTask, DALM.FullTask>(task));
        }

        public bool Update(FullTask list)
        {
            throw new NotImplementedException();
        }
    }
}
