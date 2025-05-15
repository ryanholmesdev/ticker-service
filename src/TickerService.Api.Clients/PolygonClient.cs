using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using TickerService.Api.Clients.Contracts.Responses;

namespace TickerService.Api.Clients;

public class PolygonClient : IPolygonClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public PolygonClient(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _apiKey = config["Polygon:ApiKey"] ?? throw new InvalidOperationException("Polygon API key missing");
    }
    
    public async Task<IReadOnlyList<TickerSearchResult>> SearchTickersAsync(string query, CancellationToken cancellationToken = default)
    {
        var url = $"/v3/reference/tickers?search={query}&active=true&limit=10&apiKey={_apiKey}";
        var response = await _httpClient.GetFromJsonAsync<PolygonSearchResponse>(url, cancellationToken);

        return response?.Results?.Select(r => new TickerSearchResult
        {
            Symbol = r.Ticker,
            Name = r.Name ?? ""
        }).ToList() ?? new List<TickerSearchResult>();
    }

    public async Task<TickerDetailResult?> GetTickerDetailsAsync(string symbol, CancellationToken cancellationToken = default)
    {
        var url = $"/v3/reference/tickers/{symbol}?apiKey={_apiKey}";
        var response = await _httpClient.GetFromJsonAsync<PolygonDetailResponse>(url, cancellationToken);
        var result = response?.Results;

        if (result == null) return null;

        return new TickerDetailResult
        {
            Symbol = result.Ticker,
            Name = result.Name ?? "",
            Market = result.Market ?? "",
            Locale = result.Locale ?? "",
            Exchange = result.PrimaryExchange ?? "",
            Currency = result.CurrencyName ?? "",
            Description = result.Description ?? "",
            HomepageUrl = result.HomepageUrl ?? "",
            LogoUrl = result.Branding?.LogoUrl ?? "",
            MarketCap = result.MarketCap.HasValue ? Convert.ToInt64(result.MarketCap.Value) : null,
            Employees = result.TotalEmployees
        };
    }
}