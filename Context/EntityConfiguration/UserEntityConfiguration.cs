using Microsoft.AspNetCore.Identity;

namespace SneakerServer.Context.EntityConfiguration;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    // Maps to the AspNetUsers table
    builder.ToTable("AspNetUsers");
    // A concurrency token for use with the optimistic concurrency checking
    builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();
    // builder.HasData(new User("Alessio", "Orvieto", new DateTime(1989, 10, 13), null));
    builder.OwnsOne(
      e => e.StreetAddress,
      sa =>
      {
        sa.Property(p => p.Address).IsRequired();
        sa.Property(p => p.State).IsRequired();
        sa.Property(p => p.City).IsRequired();
      });
    builder.Navigation(e => e.StreetAddress).IsRequired();
  }
}