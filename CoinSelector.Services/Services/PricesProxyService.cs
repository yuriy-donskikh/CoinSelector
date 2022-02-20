namespace CoinSelector.Services.Services;

public class PricesProxyService : IPricesProxyService
{
    private readonly IThirdPartyPrices _client;
    private readonly ISetUserService _setUserService;
    private readonly IGetUserService _getUserService;

    public PricesProxyService(IThirdPartyPrices client, ISetUserService setUserService, IGetUserService getUserService)
    {
        _client = client;
        _setUserService = setUserService;
        _getUserService = getUserService;
    }

    public async Task<Guid> SetPriceAsync(Model.SetRequest request, CancellationToken cancellationToken)
    {
        var id = await _setUserService.SetUserAsync(new Model.User { UserName = request.Name }, cancellationToken);
        var price = await _client.GetPriceAsync(request.Currency, cancellationToken);
        await _setUserService.SetPriceAsync(id, price, cancellationToken);
        return id;
    }

    public async Task UpdatePriceAsync(Guid id, string currency, CancellationToken cancellationToken)
    {
        await _getUserService.GetUserAsync(id, cancellationToken);
        var price = await _client.GetPriceAsync(currency, cancellationToken);
        await _setUserService.SetPriceAsync(id, price, cancellationToken);
    }
}
