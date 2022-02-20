namespace CoinSelector.Data.Seeders;

public class SeederService : ISeeder
{
    private readonly CoinDbContext _context;

    public SeederService(CoinDbContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    public async Task Seed()
    {
        if (_context.Users.Any()) return;
        var user = new User { Id = Guid.NewGuid(), UserName = "Yuriy", Price = new() { Buy = "BTC", Sell = "AUD" } };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}