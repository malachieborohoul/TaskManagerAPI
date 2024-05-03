using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Models.Domain;
using TaskManagerAPI.Repositories;

namespace statusManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;
        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var status = await _statusRepository.GetAll();
            return Ok(status);
        }
    
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var status = await _statusRepository.GetById(id);

            if (status == null)
            {
                return NotFound();
            }
            return Ok(status);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Status status)
        {
            var tk= await _statusRepository.Create(status);
            return Ok(tk);
        }
        
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Status status)
        {
            var tk= await _statusRepository.Update(id,status);
            return Ok(tk);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var status = await _statusRepository.Delete(id);
            return Ok(status);
        }
    }
}
