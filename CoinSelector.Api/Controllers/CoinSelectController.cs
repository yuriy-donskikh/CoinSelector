namespace CoinSelector.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CoinSelectController : ControllerBase
{
    private readonly ILogger<CoinSelectController> _logger;
    private readonly IGetUserService _getUserService;
    private readonly IPricesProxyService _pricesProxyService;
    private readonly ISetUserService _setUserService;

    public CoinSelectController(ILogger<CoinSelectController> logger, IGetUserService getUserService, IPricesProxyService pricesProxyService, ISetUserService setUserService)
    {
        _logger = logger;
        _getUserService = getUserService;
        _pricesProxyService = pricesProxyService;
        _setUserService = setUserService;
    }

    [HttpGet("/AllUsers")]
    public async Task<IActionResult> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Method:{nameof(GetAllUsersAsync)}");
        try
        {
            return Ok(await _getUserService.GetAllUsersAsync(cancellationToken));
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Method:{nameof(GetAllUsersAsync)}");
            return BadRequest(e.Message);
        }
    }

    [HttpGet("/User/{id}")]
    public async Task<IActionResult> GetUserAsync(Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Method:{nameof(GetUserAsync)}");
        try
        {
            return Ok(await _getUserService.GetUserAsync(id, cancellationToken));
        }
        catch(UserNotExistsException ue)
        {
            _logger.LogError(ue, $"Method:{nameof(GetUserAsync)}");
            return NotFound(ue.Id);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Method:{nameof(GetUserAsync)}");
            return BadRequest(e.Message);
        }
    }

    [HttpPost("/User")]
    public async Task<IActionResult> SetUserAsync(Models.SetRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Method:{nameof(SetUserAsync)}");
        try
        {
            var id = await _pricesProxyService.SetPriceAsync(request, cancellationToken);
            return Ok(id);
        }
        catch (UserNotExistsException ue)
        {
            _logger.LogError(ue, $"Method:{nameof(SetUserAsync)}");
            return NotFound(ue.Id);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Method:{nameof(SetUserAsync)}");
            return BadRequest(e.Message);
        }
    }

    [HttpPut("/User/{id}/{currency}")]
    public async Task<IActionResult> UpdateUserAsync(Guid id, string currency, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Method:{nameof(UpdateUserAsync)}");
        try
        {
            await _pricesProxyService.UpdatePriceAsync(id, currency, cancellationToken);
            return Ok();
        }
        catch (UserNotExistsException ue)
        {
            _logger.LogError(ue, $"Method:{nameof(UpdateUserAsync)}");
            return NotFound(ue.Id);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Method:{nameof(UpdateUserAsync)}");
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("/User/{id}")]
    public async Task<IActionResult> DeleteUserAsync(Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Method:{nameof(DeleteUserAsync)}");
        try
        {
            await _setUserService.DeleteUserAsync(id, cancellationToken);
            return Ok();
        }
        catch (UserNotExistsException ue)
        {
            _logger.LogError(ue, $"Method:{nameof(DeleteUserAsync)}");
            return NotFound(ue.Id);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Method:{nameof(DeleteUserAsync)}");
            return BadRequest(e.Message);
        }
    }
}
