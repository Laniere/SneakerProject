namespace SneakerServer.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class SneakerController(ILogger logger, SneakerContext context) : ControllerBase
{
  private readonly ILogger _logger = logger;
  private readonly GenericRepository<Sneaker> _repository = new(context);


}
