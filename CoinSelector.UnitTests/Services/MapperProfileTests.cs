namespace CoinSelector.UnitTests.Services;

public class MapperProfileTests : IClassFixture<MapperFixture>
{
    private readonly IMapper _mapper;

    public MapperProfileTests(MapperFixture mapperFixture)
    {
        _mapper = mapperFixture.Mapper;
    }

    [Fact]
    public void Configuration()
    {
        _mapper.ConfigurationProvider.AssertConfigurationIsValid();
    }

}
