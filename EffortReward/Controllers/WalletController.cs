using EffortReward.Data.Dto.incoming;
using EffortReward.Data.Entities;
using EffortReward.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EffortReward.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class WalletController : ControllerBase
{
    private readonly WalletService _service;

    public WalletController(WalletService service)
    {
        _service = service;
    }

    /// <summary>
    /// Get all available wallets
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="500">Internal server error</response>
    [HttpGet]
    [ProducesResponseType(typeof(Wallet[]), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> All()
    {
        var allWallets = await _service.FindAll();

        return Ok(allWallets);
    }

    /// <summary>
    /// Find specific wallet by id
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Found successfully</response>
    /// <response code="404">Not found</response>
    /// <response code="500">Internal server error</response>
    [HttpGet("id")]
    [ProducesResponseType(typeof(Wallet), StatusCodes.Status200OK)]
    public async Task<IActionResult> FindOne(int id)
    {
        var wallet = await _service.FindOne(id);

        if (wallet == null)
        {
            return NotFound();
        }

        return Ok(wallet);
    }

    /// <summary>
    /// Create a new wallet
    /// </summary>
    /// <param name="wallet"></param>
    /// <response code="201">Created successfully</response>
    /// <response code="400">Validation failed</response>
    /// <response code="500">Internal server error</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Store(CreateWalletDto wallet)
    {
        var isCreated = await _service.StoreOne(wallet) == 1;

        return StatusCode(isCreated ? 201 : 500);
    }

    /// <summary>
    /// Update specific wallet by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="walletDto"></param>
    /// <response code="204">Updated successfully</response>
    /// <response code="404">Not found</response>
    /// <response code="500">Internal server error</response>
    [HttpPut("id")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update(int id, UpdateWalletDto walletDto)
    {
        try
        {
            var wallet = new Wallet(walletDto.Points, walletDto.UserId, DateTime.UtcNow);
            wallet.Id = id;
            await _service.UpdateOne(wallet);
        }
        catch (DbUpdateConcurrencyException)
        {
            var isWalletExisting = _service.IsWalletExisting(id);

            return !isWalletExisting ? NotFound() : Problem();
        }

        
        return NoContent();
    }

    /// <summary>
    /// Destroy specific wallet by id
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Destroyed successfully</response>
    /// <response code="404">Not found</response>
    /// <response code="500">Internal server error</response>
    [HttpDelete("id")]
    public async Task<IActionResult> Destroy(int id)
    {
        try
        {
            var wallet = await _service.FindOne(id);

            if (wallet == null)
            {
                return NotFound();
            }
            
            await _service.DestroyOne(wallet);
        }
        catch (DbUpdateException)
        {
            return Problem();
        }

        return Ok();
    } 
}