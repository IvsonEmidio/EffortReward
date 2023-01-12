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

        /// <summary>
        /// Find all efforts
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [ProducesResponseType(typeof(Effort[]), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> All()
        {
            var efforts = await _service.FindAll();

            return Ok(efforts);
        }

        /// <summary>
        /// Find specific effort by id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Found successfully</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("id")]
        [ProducesResponseType(typeof(Effort), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FindOne(int id)
        {
            var effort = await _service.FindOne(id);

            if (effort == null)
            {
                return NotFound();
            }

            return Ok(effort);
        }

        /// <summary>
        /// Create new effort
        /// </summary>
        /// <param name="effort"></param>
        /// <response code="201">Created successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Store(Effort effort)
        {
            var isStored = await _service.StoreOne(effort);

            return StatusCode(isStored ? 201 : 500);
        }

        /// <summary>
        /// Update effort
        /// </summary>
        /// <param name="id"></param>
        /// <param name="effort"></param>
        /// <response code="204">Updated successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Item not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Delete specific effort
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Deleted successfully</response>
        /// <response code="404">Item not found</response>
        /// <response code="500">Internal server error</response>
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