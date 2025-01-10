using SneakerServer.Models.Mappers;
namespace SneakerServer.Controllers;

[ApiController]
[Route("[controller]")]
// [Authorize]
public class SneakerController(ILogger<SneakerController> logger, SneakerContext context) : ControllerBase
{
  private readonly ILogger _logger = logger;
  private readonly SneakerContext _context = context;

  [HttpGet()]
  [ProducesResponseType(200)]
  public async Task<ActionResult<IEnumerable<Sneaker>>> GetAll()
  {
    return await _context.Sneakers.AsNoTracking()
      .ToListAsync();
  }

  [HttpGet()]
  [ProducesResponseType(200)]
  public async Task<ActionResult<IEnumerable<SneakerDashboardDTO>>> GetAllDashboard()
  {
    return await _context.Sneakers.AsNoTracking()
      .Select(x => x.MapToDTO())
      .ToListAsync();
  }
}
