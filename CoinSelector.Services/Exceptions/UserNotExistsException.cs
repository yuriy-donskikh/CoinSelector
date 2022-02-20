namespace CoinSelector.Services.Exceptions;

[Serializable]
public class UserNotExistsException : Exception
{
    public UserNotExistsException(Guid id) : base($"User ID {id} is not found!")
    {
        Id = id;
    }

    public Guid Id { get; }
}
