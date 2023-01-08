
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trelolo.Models.Project;
using BLLM = BLL.Models.Project;

namespace Trelolo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            this._projectService = projectService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_projectService.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_projectService.GetById(id));
        }

        [HttpGet("getByUser/{idUser:int}")]
        public IActionResult GetByUser(int idUser)
        {
            return Ok(_projectService.GetByUser(idUser));
        }

        [HttpPost]
        public IActionResult Create(NewProject project)
        {
            if (!ModelState.IsValid) return BadRequest();

            _projectService.Create(new BLLM.NewProject
            {
                Name = project.Name,
                IdUser = project.IdUser
            });

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Project project)
        {
            _projectService.Update(new BLLM.Project
            {
                Id = project.Id,
                Name = project.Name,
                CreationDate = project.CreationDate,
                IdUser = project.IdUser
            });

            return Ok();
        }
    }
}
