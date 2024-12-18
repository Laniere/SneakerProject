namespace SneakerServer.Models
{
  [Owned]
  public class StreetAddress
  {
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
  }
}