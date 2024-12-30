using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
namespace SneakerServer.Models;
[Index(nameof(UserName))]
public class User(string name, string lastName, DateTime birthday, DateTime? lastAccess) : IdentityUser<Guid>
{
  public DateTime? LastAccess { get; set; } = lastAccess ?? null;
  public string Name { get; set; } = name;
  public string LastName { get; set; } = lastName;
  public DateTime Birthday { get; set; } = birthday;
  public StreetAddress StreetAddress { get; set; } = null!;

}