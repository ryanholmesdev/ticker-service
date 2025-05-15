using Microsoft.AspNetCore.Mvc;

namespace TickerService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TickerController : ControllerBase
{
    [HttpGet("search")]
    public IActionResult Search([FromQuery] string q)
    {
        if (string.IsNullOrWhiteSpace(q))
            return BadRequest("Query is required.");
        
        var results = new[]
        {
            new { Symbol = "TSLA", Name = "Tesla Inc." },
            new { Symbol = "AAPL", Name = "Apple Inc." }
        };

        return Ok(results.Where(t => t.Symbol.Contains(q, StringComparison.OrdinalIgnoreCase)));
    }
}