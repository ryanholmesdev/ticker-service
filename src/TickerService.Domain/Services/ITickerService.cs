using TickerService.Api.Clients.Contracts.Responses;

namespace TickerService.Domain.Services;

public interface ITickerService
{
    Task<IReadOnlyList<TickerSearchResult>> SearchAsync(string query, CancellationToken cancellationToken = default);
    Task<TickerDetailResult?> GetDetailsAsync(string symbol, CancellationToken cancellationToken = default);
}