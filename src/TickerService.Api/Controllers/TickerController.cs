using Microsoft.AspNetCore.Mvc;
using TickerService.Domain.Services;

namespace TickerService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TickerController : ControllerBase
{
    private readonly ITickerService _tickerService;
    public TickerController(ITickerService tickerService)
    {
        _tickerService = tickerService;
    }
    
    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string q)
    {
        if (string.IsNullOrWhiteSpace(q))
            return BadRequest("Query parameter 'q' is required.");

        var results = await _tickerService.SearchAsync(q);
        return Ok(results);
    }

    [HttpGet("{symbol}")]
    public async Task<IActionResult> GetDetails(string symbol)
    {
        var result = await _tickerService.GetDetailsAsync(symbol);
        return result == null ? NotFound() : Ok(result);
    }
}