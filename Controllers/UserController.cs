using Microsoft.AspNetCore.Mvc;

namespace SneakerServer.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase //controller add ViewBag and ViewResult. not necessary for pure asp.net core WebAPI
{
  private readonly SneakerContext _context;
  private readonly ILogger<UserController> _logger;

  public UserController(ILogger<UserController> logger, SneakerContext context)
  {
    _logger = logger;
    _context = context;
  }

  [HttpGet(Name = "User")]
  public User Get() => _context.Users.FirstOrDefault() ?? throw new Exception("User not found!");

  
}