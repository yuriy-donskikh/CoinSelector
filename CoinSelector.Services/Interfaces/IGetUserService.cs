namespace CoinSelector.Services.Interfaces;

public interface IGetUserService
{
    Task<List<Model.UserInfo>> GetAllUsersAsync(CancellationToken cancellationToken);
    Task<Model.User> GetUserAsync(Guid id, CancellationToken cancellationToken);
}
