namespace SneakerServer.Models.PriceStrategy;

public class NoCollab : IPriceCalculator
{
  private readonly string _collabType = "NoCollab";
  public bool AppliesTo(string collabType) => _collabType == collabType;

  public decimal CalculatePrice(decimal price) => price;
}

public class Travis : IPriceCalculator
{
  private readonly string _collabType = "Travis";
  public bool AppliesTo(string collabType) => _collabType == collabType;

  public decimal CalculatePrice(decimal price) => price + 50;
}

// var container = new Container(x => x.Scan(scan =>
// {
//   scan.TheCallingAssembly();
//   scan.WithDefaultConventions();
//   scan.AddAllTypesOf<IPriceCalculator>();
// }