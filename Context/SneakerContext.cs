public class SneakerContext(DbContextOptions<SneakerContext> options) : DbContext(options)
{
  public DbSet<Sneaker> Sneakers { get; set; } = null!;
  public DbSet<Brand> Brands { get; set; } = null!;
  public DbSet<User> Users { get; set; } = null!;
  private readonly string _connectionString = @"Data Source=DESKTOP-7P5OR8C;Initial Catalog=sneakers;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer(
        _connectionString).UseSeeding((context, _) =>
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
    });

    modelBuilder.Entity<Brand>(e =>
    {
      e.Property(e => e.BrandId).ValueGeneratedOnAdd();
      e.HasMany(e => e.Sneakers)
      .WithOne(e => e.Brand)
      .HasForeignKey(e => e.SneakerId)
      .OnDelete(DeleteBehavior.Cascade);

      e.HasData(
        new Brand { BrandId = 1, Name = "Adidas" },
        new Brand { BrandId = 2, Name = "New Balance" },
        new Brand { BrandId = 3, Name = "Saucony" },
        new Brand { BrandId = 4, Name = "Asics" },
        new Brand { BrandId = 5, Name = "Timberland" }
      );
    });

    modelBuilder.Entity<Brand>()
     .Navigation(e => e.Sneakers)
     .UsePropertyAccessMode(PropertyAccessMode.Property);

    modelBuilder.Entity<Sneaker>()
      .Navigation(e => e.Brand)
      .UsePropertyAccessMode(PropertyAccessMode.Property);

    modelBuilder.Entity<User>()
      .HasKey(e => e.UserId);
  }
}

// var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
//     .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test;ConnectRetryCount=0")
//     .Options;

// using var context = new ApplicationDbContext(contextOptions);