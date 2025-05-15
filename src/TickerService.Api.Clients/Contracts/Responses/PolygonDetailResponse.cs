namespace TickerService.Api.Clients.Contracts.Responses;

public class PolygonDetailResponse
{
    public PolygonDetailResult? Results { get; set; }
}

public class PolygonDetailResult
{
    public string Ticker { get; set; }
    public string? Name { get; set; }
    public string? Market { get; set; }
    public string? Locale { get; set; }
    public string? PrimaryExchange { get; set; }
    public string? CurrencyName { get; set; }
    public string? Description { get; set; }
    public string? HomepageUrl { get; set; }
    public Branding? Branding { get; set; }
    public double? MarketCap { get; set; }
    public int? TotalEmployees { get; set; }
}

public class Branding
{
    public string? LogoUrl { get; set; }
    public string? IconUrl { get; set; }
}