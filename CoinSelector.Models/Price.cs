namespace CoinSelector.Models;

public record Price(
    string Sell, 
    string Buy, 
    double? Ask = null, 
    double? Bid = null, 
    double? Rate = null, 
    double? spotRate =null, 
    DateTime? Timestamp =null
    );