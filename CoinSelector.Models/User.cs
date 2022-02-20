namespace CoinSelector.Models;

public record User(
    Guid? Id = null, 
    string? UserName = null,
    Price? Price = null
    );