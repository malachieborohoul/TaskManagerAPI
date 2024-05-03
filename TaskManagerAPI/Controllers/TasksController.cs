using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Data;
using TaskManagerAPI.Models.Domain;
using TaskManagerAPI.Repositories;

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskRepository.GetAll();
            return Ok(tasks);
        }
    
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var task = await _taskRepository.GetById(id);

            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Tasks task)
        {
           var tk= await _taskRepository.Create(task);
           return Ok(tk);
        }
        
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Tasks task)
        {
            var tk= await _taskRepository.Update(id,task);
            return Ok(tk);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var task = await _taskRepository.Delete(id);
            return Ok(task);
        }
    }
}
