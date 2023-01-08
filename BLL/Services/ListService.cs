using BLL.Interfaces;
using BLL.Models.List;
using DAL.Interfaces;
using DALM = DAL.Models.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Mapper;

namespace BLL.Services
{
    public class ListService : ObjectMapper, IListService
    {
        private readonly IListRepo _listRepo;

        public ListService(IListRepo listRepo)
        {
            _listRepo = listRepo;   
        }

        public bool Create(NewList list)
        {
            return _listRepo.Create(MapModel<DALM.NewList, NewList>(list));
        }

        public bool Delete(int id)
        {
            return _listRepo.Delete(id);
        }

        public IEnumerable<TaskList> GetAll()
        {
            return _listRepo.GetAll()
                .Select(list => MapModel<TaskList, DALM.TaskList>(list));
        }

        public TaskList GetById(int id)
        {
            return MapModel<TaskList, DALM.TaskList>(_listRepo.GetById(id));
        }

        public bool Update(TaskList list)
        {
            return _listRepo.Update(MapModel<DALM.TaskList, TaskList>(list));
        }

        public IEnumerable<TaskList> GetByProject(int idProject)
        {
            return _listRepo.GetByProject(idProject)
                .Select(list => MapModel<TaskList, DALM.TaskList>(list));
        }
    }
}
