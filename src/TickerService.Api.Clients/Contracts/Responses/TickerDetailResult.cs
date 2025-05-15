namespace TickerService.Api.Clients.Contracts.Responses;

public class TickerDetailResult
{
    public string Symbol { get; set; }
    public string Name { get; set; }
    public string Market { get; set; }
    public string Locale { get; set; }
    public string Exchange { get; set; }
    public string Currency { get; set; }
    public string Description { get; set; }
    public string HomepageUrl { get; set; }
    public string LogoUrl { get; set; }
    public long? MarketCap { get; set; }
    public int? Employees { get; set; }
}