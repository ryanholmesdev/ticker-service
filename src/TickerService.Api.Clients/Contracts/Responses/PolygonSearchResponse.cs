namespace TickerService.Api.Clients.Contracts.Responses;

public class PolygonSearchResponse
{
    public List<PolygonTickerSummary>? Results { get; set; }
}

public class PolygonTickerSummary
{
    public string Ticker { get; set; }
    public string? Name { get; set; }
}