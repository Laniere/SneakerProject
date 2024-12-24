using SneakerServer.Context.EntityConfiguration;

namespace SneakerServer.Context
{
  public class SneakerContext(DbContextOptions<SneakerContext> options) : DbContext(options)
  {
    public DbSet<Sneaker> Sneakers { get; set; } = null!;
    public DbSet<Brand> Brands { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

      optionsBuilder.UseSqlServer().UseSeeding((context, _) =>
          {
            Brand? nike = context.Set<Brand>().FirstOrDefault(b => b.Name == "Nike");
            if (nike == null)
            {
              context.Set<Brand>().Add(new Brand { Name = "Nike" });
              context.SaveChanges();
            }
          });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Sneaker>(e =>
      {
        e.Property(e => e.SneakerId).ValueGeneratedOnAdd();
        e.HasKey(e => e.SneakerId)
        .HasName("PrimaryKey_SneakerId");
        e.Navigation(e => e.Brand)
        .UsePropertyAccessMode(PropertyAccessMode.Property);
        e.Property(e => e.RetailPrice).HasPrecision(18,2);
      });

      modelBuilder.ApplyConfiguration(new BrandEntityConfiguration());
      modelBuilder.ApplyConfiguration(new UserEntityConfiguration());

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