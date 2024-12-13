using Microsoft.AspNetCore.Mvc;

namespace SneakerServer.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

  private readonly SneakerContext _context;

  private readonly ILogger<WeatherForecastController> _logger;

  public WeatherForecastController(ILogger<WeatherForecastController> logger, SneakerContext context)
  {
    _logger = logger;
    _context = context;
  }

  [HttpGet(Name = "GetWeatherForecast")]
  public IEnumerable<WeatherForecast> Get()
  {
    var sneaker = _context.Sneakers.First();

    var contextOptions = new DbContextOptionsBuilder<SneakerContext>()
    .UseSqlServer(@"Data Source=DESKTOP-7P5OR8C;Initial Catalog=sneakers;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False")
    .Options;

    using var context = new SneakerContext(contextOptions);
    var sneaker2 = _context.Sneakers.First();


    return Enumerable.Range(0, 5).Select(index => new WeatherForecast
    {
      Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
      TemperatureC = Random.Shared.Next(-21, 55),
    })
    .ToArray();
  }
}
