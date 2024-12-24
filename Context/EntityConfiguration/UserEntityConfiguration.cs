namespace SneakerServer.Context.EntityConfiguration;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.HasKey(e => e.UserId);
    builder.HasData(new User(1, "Admin", "test", "Alessio", "Orvieto", new DateTime(1989, 10, 13), null));
    builder.OwnsOne(
      e => e.StreetAddress,
      sa =>
      {
        sa.Property(p => p.Address).IsRequired();
        sa.Property(p => p.State).IsRequired();
        sa.Property(p => p.City).IsRequired();
      });
    builder.Navigation(e => e.StreetAddress).IsRequired();
    builder.OwnsOne(e => e.StreetAddress).HasData(new
    {
      UserId = 1,
      Address = "Via San Giorgio 31",
      City = "Prato",
      State = "Italy",
    });
  }
}