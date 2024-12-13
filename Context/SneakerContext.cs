public class SneakerContext(DbContextOptions<SneakerContext> options) : DbContext(options)
{
  public DbSet<Sneaker> Sneakers { get; set; } = null!;
  public DbSet<Brand> Brands { get; set; } = null!;
  public DbSet<User> Users { get; set; } = null!;
  private readonly string _connectionString = @"Data Source=DESKTOP-7P5OR8C;Initial Catalog=sneakers;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer(
        _connectionString);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Sneaker>()
      .HasKey(e => e.SneakerId)
      .HasName("PrimaryKey_SneakerId");

    modelBuilder.Entity<Brand>()
      .HasMany(e => e.Sneakers)
      .WithOne(e => e.Brand)
      .HasForeignKey(e => e.SneakerId)
      .OnDelete(DeleteBehavior.Cascade)
      .IsRequired();

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