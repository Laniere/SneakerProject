using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SneakerServer.Models
{
  [Index(nameof(UserName))]
  public class User(int userId, string userName, string password, string name, string lastName, DateTime birthday, DateTime? lastAccess)
  {
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; } = userId;
    public string UserName { get; set; } = userName;
    public string Password { get; set; } = password;
    public DateTime? LastAccess { get; set; } = lastAccess ?? null;
    public string Name { get; set; } = name;
    public string LastName { get; set; } = lastName;
    public DateTime Birthday { get; set; } = birthday;
    public StreetAddress StreetAddress { get; set; } = null!;

  }
}