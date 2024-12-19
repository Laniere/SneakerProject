using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SneakerServer.Context
{
  public readonly struct Currency(decimal amount)
  {
    public decimal Amount { get; } = amount;

    public override string ToString()
        => $"${Amount}";
  }

  public class CurrencyConverter : ValueConverter<Currency, decimal>
  {
    public CurrencyConverter() : base(
            v => v.Amount,
            v => new Currency(v))
    { }
  }
}