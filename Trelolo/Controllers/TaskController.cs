using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trelolo.Models.Task;
using BLLM = BLL.Models.Task;

namespace Trelolo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_taskService.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_taskService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create(NewTask task)
        {
            if (!ModelState.IsValid) return BadRequest();

            _taskService.Create(new BLLM.NewTask
            {
                Name = task.Name,
                DeadLine = task.DeadLine,
                IdList = task.IdList
            });

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _taskService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(FullTask task)
        {
            _taskService.Update(new BLLM.FullTask
            {
                Id = task.Id,
                Name = task.Name,
                CreationDate = task.CreationDate,
                DeadLine = task.DeadLine,
                IdList = task.IdList,
            });

            return Ok();
        }

        [HttpGet("getByList/{idList:int}")]
        public IActionResult GetByList(int idList)
        {
            return Ok(_taskService.GetByList(idList));
        }
    }
}
