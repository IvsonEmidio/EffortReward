using EffortReward.Data.Entities;
using EffortReward.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EffortReward.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeeklyHistoricalController : ControllerBase
    {
        private readonly WeeklyHistoricalService _service;
        public WeeklyHistoricalController(WeeklyHistoricalService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var histories = await this._service.All();

            return Ok(histories);
        }


        [HttpGet("id")]
        public async Task<IActionResult> FindOneAsync(int id)
        {
            var history = await this._service.FindOne(id);


            if (history != null)
            {
                return Ok(history);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> StoreOne(WeeklyHistory history) {
            try
            {
                await this._service.Store(history);

                return StatusCode(201);
            } catch (Exception) {
                return StatusCode(500);
            }
        }

        [HttpPut("id")]
        public async Task<ActionResult> UpdateOne(int id, WeeklyHistory history) {
            try
            {
                history.Id = id;
                await this._service.Update(history);
            } catch (DbUpdateConcurrencyException) { 
                if (!this._service.IsHistoryExisting(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }
    }
}
