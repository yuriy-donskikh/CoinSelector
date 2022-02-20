namespace CoinSelector.Services.Interfaces
{
    public interface IPricesProxyService
    {
        Task<Guid> SetPriceAsync(Model.SetRequest request, CancellationToken cancellationToken);
        Task UpdatePriceAsync(Guid id, string currency, CancellationToken cancellationToken);
    }
}