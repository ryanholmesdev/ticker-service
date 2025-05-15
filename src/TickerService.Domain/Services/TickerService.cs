using TickerService.Api.Clients;
using TickerService.Api.Clients.Contracts.Responses;

namespace TickerService.Domain.Services;

public class TickerService : ITickerService
{
    private readonly IPolygonClient _polygonClient;

    public TickerService(IPolygonClient polygonClient)
    {
        _polygonClient = polygonClient;
    }

    public Task<IReadOnlyList<TickerSearchResult>> SearchAsync(string query, CancellationToken cancellationToken = default)
    {
        return _polygonClient.SearchTickersAsync(query, cancellationToken);
    }

    public Task<TickerDetailResult?> GetDetailsAsync(string symbol, CancellationToken cancellationToken = default)
    {
        return _polygonClient.GetTickerDetailsAsync(symbol, cancellationToken);
    }
}