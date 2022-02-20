namespace CoinSelector.UnitTests.Services;

public class UserServiceTests:IClassFixture<MapperFixture>, IClassFixture<DataFixture>
{
    private readonly MapperFixture _mapper;
    private readonly DataFixture _data;

    public UserServiceTests(MapperFixture mapper, DataFixture data)
    {
        _mapper = mapper;
        _data = data;
    }

    [Fact]
    public async Task GetAllUsersAsyncTest()
    {
        //Arrange
        var userService = new UserService(_data.DbContext.Object, _mapper.Mapper);
        var expected = _mapper.Mapper.Map<List<Model.UserInfo>>(_data.GetUserData());

        //Act
        var result = await userService.GetAllUsersAsync(default);

        //Assert
        Assert.Single(result);
        Assert.Equal(expected.First(), result.First());
    }

    [Fact]
    public async Task GetUserAsync()
    {
        //Arrange
        var userService = new UserService(_data.DbContext.Object, _mapper.Mapper);
        var expected = _mapper.Mapper.Map<Model.User>(_data.GetUserData()[0]);

        //Act
        var result = await userService.GetUserAsync(_data.Id, default);

        //Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task SetUserAsyncTest()
    {
        //Arrange
        var userService = new UserService(_data.DbContext.Object, _mapper.Mapper);
        var request = _mapper.Mapper.Map<Model.User>(_data.GetUserData()[0]);

        //Act
        var result = await userService.SetUserAsync(request, default);

        //Assert
        Assert.NotEqual(_data.Id, result);
    }

    [Fact]
    public async Task SetPriceAsyncTest()
    {
        //Arrange
        var userService = new UserService(_data.DbContext.Object, _mapper.Mapper);
        var expected = _mapper.Mapper.Map<Model.Price>(_data.GetPriceData()[0]);

        //Act
        await userService.SetPriceAsync(_data.Id, expected, default);

        //Assert
        //Test will fail if error happened
    }

    [Fact]
    public async Task DeleteUserAsyncTest()
    {
        //Arrange
        var userService = new UserService(_data.DbContext.Object, _mapper.Mapper);

        //Act
        await userService.DeleteUserAsync(_data.Id, default);

        //Assert
        //Test will fail if error happened
    }
}
