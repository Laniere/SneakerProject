using System.ComponentModel.DataAnnotations.Schema;
namespace SneakerServer.Models
{
  [Index(nameof(UserName))]
  public class User
  {
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public DateTime LastAccess { get; set; }
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public DateTime Birthday { get; set; }
  }
}