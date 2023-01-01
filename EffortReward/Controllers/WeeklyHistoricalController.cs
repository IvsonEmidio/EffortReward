using EffortReward.Data.Entities;
using EffortReward.Services;
using Microsoft.AspNetCore.Http.HttpResults;
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

        /// <summary>
        /// Find all histories.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(WeeklyHistory[]), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            var histories = await this._service.All();

            return Ok(histories);
        }

        /// <summary>
        /// Find specific history by id.
        /// </summary>
        /// <response code="404">Not found</response>
        [HttpGet("id")]
        [ProducesResponseType(typeof(WeeklyHistory), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindOneAsync(int id)
        {
            var history = await this._service.FindOne(id);


            if (history != null)
            {
                return Ok(history);
            }

            return NotFound();
        }

        /// <summary>
        /// Create weekly history
        /// </summary>
        /// <response code="201">Created successfully</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(201)]
        [HttpPost]
        public async Task<ActionResult> StoreOne(WeeklyHistory history)
        {
            try
            {
                await this._service.Store(history);

                return StatusCode(201);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Create weekly history
        /// </summary>
        /// <response code="204">Updated sucessfully</response>
        /// <response code="404">Item not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("id")]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> UpdateOne(int id, WeeklyHistory history)
        {
            try
            {
                history.Id = id;
                await this._service.Update(history);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this._service.IsHistoryExisting(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Delete specific history
        /// </summary>
        /// <response code="200">Destroyed successfully</response>
        /// <response code="404">Item not found</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete("id")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Destroy(int id)
        {
            var history = await this._service.FindOne(id);

            if (history == null)
            {
                return NotFound();
            }

            var isDestroyed = await this._service.Destroy(history) == 1;

            if (isDestroyed)
            {
                return Ok();
            }

            return StatusCode(500);
        }
    }
}
