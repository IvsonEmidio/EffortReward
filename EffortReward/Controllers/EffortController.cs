

using EffortReward.Data.Entities;
using EffortReward.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EffortReward.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EffortController : ControllerBase
    {
        private readonly EffortService _service;
        
        public EffortController(EffortService effortService)
        {
            _service = effortService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var efforts = await _service.FindAll();

            return Ok(efforts);
        }

        [HttpGet("id")]
        public async Task<IActionResult> FindOne(int id)
        {
            var effort = await _service.FindOne(id);

            if (effort == null)
            {
                return NotFound();
            }

            return Ok(effort);
        }

        [HttpPost]
        public async Task<IActionResult> Store(Effort effort)
        {
            var isStored = await _service.StoreOne(effort);

            return StatusCode(isStored ? 201 : 500);
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, Effort effort)
        {
            try
            {
                effort.Id = id;
                await _service.UpdateOne(effort);
            }
            catch (DbUpdateConcurrencyException)
            {
                var isExisting = _service.IsEffortExisting(id);

                return !isExisting ? NotFound() : StatusCode(500);
            }

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Destroy(int id)
        {
            var effort = await _service.FindOne(id);

            if (effort != null)
            {
                var isRemoved = await _service.DeleteOne(effort);

                if (isRemoved)
                {
                    return Ok();
                }
            }
            else
            {
                return NotFound();
            }

            return StatusCode(500);
        }
    }
}