namespace CoinSelector.Data.Entities;

public class Price
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string Sell { get; set; } = string.Empty;
    public string Buy { get; set; } = string.Empty;
    public double? Ask { get; set; }
    public double? Bid { get; set; }
    public double? Rate { get; set; }
    public double? spotRate { get; set; }
    public DateTime? Timestamp { get; set; }
}
