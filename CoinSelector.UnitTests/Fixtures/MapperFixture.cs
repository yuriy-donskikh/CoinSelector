namespace CoinSelector.UnitTests.Fixtures;

public class MapperFixture
{
    public IMapper Mapper { get; }

    public MapperFixture()
    {
        var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(MapperProfile)));
        Mapper = new Mapper(config);
    }

    public void Dispose()
    {
    }
}
