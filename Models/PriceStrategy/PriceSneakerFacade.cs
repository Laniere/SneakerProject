
namespace SneakerServer.Models.PriceStrategy;

public interface IPriceStrategy
{
  decimal GetPrice(string collabType, decimal price);
}
public interface IPriceCalculator
{
  public bool AppliesTo(string collabType);
  public decimal CalculatePrice(decimal price);
}

public class PriceStrategy(IPriceCalculator[] priceCalculators = null!) : IPriceStrategy
{
  private readonly IPriceCalculator[] _priceCalculators = priceCalculators;

  public decimal GetPrice(string collabType, decimal price)
  {
    IPriceCalculator? calculator = _priceCalculators.FirstOrDefault(x => x.AppliesTo(collabType));
    if (calculator is null)
    {
      return price;
    }
    return calculator.CalculatePrice(price);
  }
}

public class PriceSneakerFacade
{
  private readonly Container _container;
  public PriceSneakerFacade() => _container = new(x => x.Scan(scan =>
                                 {
                                   scan.TheCallingAssembly();
                                   scan.WithDefaultConventions();
                                   scan.AddAllTypesOf<IPriceCalculator>();
                                 }));
  public decimal GetPrice(Sneaker sneaker)
  {
    IPriceStrategy strategy = _container.GetInstance<IPriceStrategy>();
    return strategy.GetPrice(sneaker.Collaboration, sneaker.RetailPrice);
  }
}