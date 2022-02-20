namespace CoinSelector.Services.Interfaces;

public interface ISetUserService
{
    Task SetPriceAsync(Guid id, Model.Price price, CancellationToken cancellationToken);
    Task<Guid> SetUserAsync(Model.User user, CancellationToken cancellationToken);
    Task DeleteUserAsync(Guid id, CancellationToken cancellationToken);
}
