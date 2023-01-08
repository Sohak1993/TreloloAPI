using BLL.Interfaces;
using BLL.Models.Project;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Mapper;
using DALM = DAL.Models.Project;

namespace BLL.Services
{
    public class ProjectService : ObjectMapper, IProjectService
    {
        private readonly IProjectRepo _projectRepo;

        public ProjectService(IProjectRepo projectRepo)
        {
            this._projectRepo = projectRepo;
        }

        public bool Create(NewProject project)
        {
            return _projectRepo.Create(MapModel<DALM.NewProject, NewProject>(project));
        }

        public bool Delete(int id)
        {
            return _projectRepo.Delete(id);
        }

        public IEnumerable<Project> GetAll()
        {
            return _projectRepo.GetAll()
                .Select(project => MapModel<Project, DALM.Project>(project));
        }

        public Project GetById(int id)
        {
            return MapModel<Project, DALM.Project>(_projectRepo.GetById(id));
        }

        public bool Update(Project project)
        {    
            return _projectRepo.Update(MapModel<DALM.Project, Project>(project));
        }

        public IEnumerable<Project> GetByUser(int idUser)
        {
            return _projectRepo.GetByUser(idUser)
                .Select(project => MapModel<Project, DALM.Project>(project));
        }
    }
}
