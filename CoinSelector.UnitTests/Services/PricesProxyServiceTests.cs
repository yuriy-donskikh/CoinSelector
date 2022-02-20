namespace CoinSelector.UnitTests.Services;

public class PricesProxyServiceTests:IClassFixture<DataFixture>, IClassFixture<MapperFixture>
{
    private readonly DataFixture _data;
    private readonly MapperFixture _mapper;

    public PricesProxyServiceTests(DataFixture data, MapperFixture mapper)
    {
        _data = data;
        _mapper = mapper;
    }

    [Fact]
    public async Task SetPriceAsyncTest()
    {
        //Arrange
        var client = new Mock<IThirdPartyPrices>();
        client.Setup(i => i.GetPriceAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(_mapper.Mapper.Map<Model.Price>(_data.GetPriceData()[0]));
        var id= Guid.NewGuid();
        var setUserService = new Mock<ISetUserService>();
        setUserService.Setup(i => i.SetUserAsync(It.IsAny<Model.User>(), It.IsAny<CancellationToken>())).ReturnsAsync(id);
        var getUserService = new Mock<IGetUserService>();
        var service = new PricesProxyService(client.Object, setUserService.Object, getUserService.Object);

        //Act
        var result = await service.SetPriceAsync(new("test", "test"), default);

        //Assert
        Assert.Equal(id, result);
    }

    [Fact]
    public async Task UpdatePriceAsyncTest()
    {
        //Arrange
        var client = new Mock<IThirdPartyPrices>();
        client.Setup(i => i.GetPriceAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(_mapper.Mapper.Map<Model.Price>(_data.GetPriceData()[0]));
        var id = _data.Id;
        var setUserService = new Mock<ISetUserService>();
        var getUserService = new Mock<IGetUserService>();
        var service = new PricesProxyService(client.Object, setUserService.Object, getUserService.Object);

        //Act
        await service.UpdatePriceAsync(id, "test", default);

        //Assert
        //Test fail if error happened
    }
}
