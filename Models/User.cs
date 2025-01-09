using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
namespace SneakerServer.Models;
[Index(nameof(UserName))]
public class User : IdentityUser<Guid>
{
  public DateTime? LastAccess { get; set; } = null;
  public string? Name { get; set; }
  public string? LastName { get; set; }
  public DateTime? Birthday { get; set; }
  public StreetAddress? StreetAddress { get; set; }

}