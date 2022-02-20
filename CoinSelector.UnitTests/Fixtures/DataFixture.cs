namespace CoinSelector.UnitTests.Fixtures;

public class DataFixture
{
    public Mock<CoinDbContext> DbContext => GetContext();
    public Guid Id { get; } = Guid.NewGuid();

    public List<Entity.User> GetUserData()
    {
        return new()
        {
            new()
            {
                Id = Id,
                UserName = "TestUser",
                Price = GetPriceData().First()
            }
        };
    }

    public List<Entity.Price> GetPriceData()
    {
        return new()
        {
            new()
            {
                UserId = Id,
                Buy = "BTC",
                Sell = "AUD"
            }
        };
    }

    private Mock<CoinDbContext> GetContext()
    {
        var context = new Mock<CoinDbContext>();
        context.Setup(i => i.Users).Returns(GetUserData().AsQueryable().BuildMockDbSet().Object);
        context.Setup(i => i.Prices).Returns(GetPriceData().AsQueryable().BuildMockDbSet().Object);
        context.Setup(i => i.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);
        return context;
    }
}
