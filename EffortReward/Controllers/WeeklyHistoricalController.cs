using EffortReward.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}
