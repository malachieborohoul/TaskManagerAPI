using Microsoft.AspNetCore.Mvc;
using Task = TaskManagerAPI.Models.Domain.Task;

namespace TaskManagerAPI.Controllers;

public class TaskController : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        await System.Threading.Tasks.Task.CompletedTask;
        return Ok();
    }
    
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        await System.Threading.Tasks.Task.CompletedTask;
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Task task)
    {
        await System.Threading.Tasks.Task.CompletedTask;
        return Ok(task);
    }
    
    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Task task)
    {
        await System.Threading.Tasks.Task.CompletedTask;
        return Ok(task);
    }
    
    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await System.Threading.Tasks.Task.CompletedTask;
        return Ok();
    }
}