using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SneakerServer.Context;
public class SneakerContext(DbContextOptions<SneakerContext> options) : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{
  public DbSet<Sneaker> Sneakers { get; set; } = null!;
  public DbSet<Brand> Brands { get; set; } = null!;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer().UseSeeding((context, _) =>
        {
          Sneaker? travisJordan1 = context.Set<Sneaker>().FirstOrDefault(b => b.Model == "Travis Jordan 1 High Mocha");
          Brand savedNikeBrand = context.Set<Brand>().Where(b => b.Name.Contains("Nike")).First();
          if (travisJordan1 == null)
          {
            context.Set<Sneaker>().Add(new Sneaker
            {
              Model = "Travis Jordan 1 High Mocha",
              Brand = savedNikeBrand,
              BrandId = savedNikeBrand.BrandId,
              Collaboration = "Travis",
              RetailPrice = 145,
              ReleaseYear = new DateTime(2020, 10, 12),
              ColorWay = "Mocha",
              ProductDescription = "New Travis High"
            });
            context.SaveChanges();
          }
        });
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfiguration(new BrandEntityConfiguration());
    modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
    // Is possible to set entity here
    modelBuilder.Entity<Sneaker>(e =>
    {
      e.Property(e => e.SneakerId).ValueGeneratedOnAdd();
      e.HasKey(e => e.SneakerId)
      .HasName("PrimaryKey_SneakerId");
      e.Navigation(e => e.Brand).AutoInclude();
      e.Property(e => e.RetailPrice).HasPrecision(18, 2);
    });


    #region Currency Bulk configuration
    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
    {
      foreach (var propertyInfo in entityType.ClrType.GetProperties())
      {
        if (propertyInfo.PropertyType == typeof(Currency))
        {
          entityType.AddProperty(propertyInfo)
              .SetValueConverter(typeof(CurrencyConverter));
        }
      }
    }
    #endregion
  }
}
// var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
//     .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test;ConnectRetryCount=0")
//     .Options;

// using var context = new ApplicationDbContext(contextOptions);

// var contextOptions = new DbContextOptionsBuilder<SneakerContext>()
//   .UseSqlServer(@"Data Source=DESKTOP-7P5OR8C;Initial Catalog=sneakers;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False")
//   .Options;

// using var context = new SneakerContext(contextOptions);

// new StreetAddress { City = "Prato", Address = "Via San Giorgio 31", State = "Italy" }