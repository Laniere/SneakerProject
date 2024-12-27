namespace SneakerServer.Controllers;

[ApiController]
[Route("[controller]")]
// [Authorize]
public class SneakerController(ILogger<SneakerController> logger, SneakerContext context) : ControllerBase
{
  private readonly ILogger _logger = logger;
  private readonly GenericRepository<Sneaker> _repository = new(context);

  [HttpGet()]
  [ProducesResponseType(200)]
  public IActionResult GetAll()
  {
    IEnumerable<Sneaker> sneakers = _repository.GetAll();
    return Ok(sneakers);
  }
}
