namespace CoinSelector.Services.Services;

public class UserService : IGetUserService, ISetUserService
{
    private readonly CoinDbContext _dbContext;
    private readonly IMapper _mapper;

    public UserService(CoinDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public Task<List<Model.UserInfo>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        return _dbContext.Users.ProjectTo<Model.UserInfo>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }

    public Task<Model.User> GetUserAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            return _dbContext.Users.Where(u => u.Id == id).Include(u => u.Price).ProjectTo<Model.User>(_mapper.ConfigurationProvider).FirstAsync(cancellationToken);
        }
        catch
        {
            throw new UserNotExistsException(id);
        }
    }

    public async Task<Guid> SetUserAsync(Model.User user, CancellationToken cancellationToken)
    {
        var userEnt = _mapper.Map<Entity.User>(user);
        userEnt.Id = new Guid();
        _dbContext.Users.Add(userEnt);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return userEnt.Id;
    }

    public async Task SetPriceAsync(Guid id, Model.Price price, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.Include(u => u.Price).FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        if (user == null) throw new UserNotExistsException(id);

        if (user.Price == null)
        {
            user.Price = _mapper.Map<Entity.Price>(price);
            user.Price.UserId = id;
        }
        else
        {
            _mapper.Map(price, user.Price);
        }
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.Where(i=>i.Id==id).Include(i=>i.Price).FirstOrDefaultAsync(cancellationToken);
        if (user == null) throw new UserNotExistsException(id);
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
