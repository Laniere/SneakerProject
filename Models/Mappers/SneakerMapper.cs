namespace SneakerServer.Models.Mappers;
public static class SneakerMapper
{
  public static SneakerDashboardDTO MapToDTO(this Sneaker entity)
  {
    return new SneakerDashboardDTO
    {
      Model = entity.Model,
      RetailPrice = entity.RetailPrice,
      Brand = entity.Brand is null ? "Not avaiable" : entity.Brand.Name,
    };
  }
}