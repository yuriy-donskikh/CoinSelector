namespace CoinSelector.Services.Interfaces;

public interface IThirdPartyPrices
{
    [Get("/aud/{currency}")]
    Task<Model.Price> GetPriceAsync(string currency, CancellationToken cancellationToken);
}
