using TickerService.Api.Clients.Contracts.Responses;

namespace TickerService.Api.Clients;

public interface IPolygonClient
{
    /// <summary>
    /// Searches for tickers by partial symbol or company name.
    /// </summary>
    /// <param name="query">The search query, e.g. "tesla" or "TSLA".</param>
    /// <param name="cancellationToken">Optional cancellation token.</param>
    /// <returns>A list of basic ticker info (symbol and name).</returns>
    Task<IReadOnlyList<TickerSearchResult>> SearchTickersAsync(string query, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets detailed metadata for a specific ticker.
    /// </summary>
    /// <param name="symbol">Ticker symbol, e.g. "AAPL".</param>
    /// <param name="cancellationToken">Optional cancellation token.</param>
    /// <returns>All enriched ticker details from Polygon, or null if not found.</returns>
    Task<TickerDetailResult?> GetTickerDetailsAsync(string symbol, CancellationToken cancellationToken = default);
}