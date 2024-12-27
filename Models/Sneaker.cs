using SneakerServer.Models.PriceStrategy;

namespace SneakerServer.Models;
[Index(nameof(Model))]
public class Sneaker
{
  //primary key by default 
  public int SneakerId { get; set; }
  public string Model { get; set; } = null!;
  public int BrandId { get; set; }
  public Brand? Brand { get; set; }
  public string Collaboration { get; set; } = "";
  public decimal RetailPrice { get; set; } = 0;
  public DateTime ReleaseYear { get; set; }
  public string ColorWay { get; set; } = "";
  public string ProductDescription { get; set; } = "";
  private readonly decimal _commercialPrice;
  public decimal CommercialPrice
  {
    get { return GetCommercialPrice(); }
  }
  public decimal GetCommercialPrice()
  {
    PriceSneakerFacade facade = new();
    return facade.GetPrice(this);
  }
}