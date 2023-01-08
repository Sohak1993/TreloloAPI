using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trelolo.Models.List;
using BLLM = BLL.Models.List;

namespace Trelolo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListService _listService;

        public ListController(IListService listService)
        {
            _listService = listService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            Console.WriteLine("Salut");
            return Ok(_listService.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_listService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create(NewList list)
        {
            if (!ModelState.IsValid) return BadRequest();

            _listService.Create(new BLLM.NewList
            {
                Name = list.Name,
                DeadLine = list.DeadLine,
                IdProject = list.IdProject
            });

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _listService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(TaskList list)
        {
            _listService.Update(new BLLM.TaskList
            {
                Id = list.Id,
                Name = list.Name,
                CreationDate = list.CreationDate,
                DeadLine = list.DeadLine,
                IdProject = list.IdProject,
            });

            return Ok();
        }

        [HttpGet("getByProject/{idProject:int}")]
        public IActionResult GetByProject(int idProject)
        {
            return Ok(_listService.GetByProject(idProject));
        }
    }
}
