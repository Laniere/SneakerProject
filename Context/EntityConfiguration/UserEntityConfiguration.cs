using Microsoft.AspNetCore.Identity;

namespace SneakerServer.Context.EntityConfiguration;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.ToTable("Users");
    builder.Property(p => p.Email).IsRequired();
    // A concurrency token for use with the optimistic concurrency checking
    builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

    builder.HasData(SeedData());
  }

  private static HashSet<User> SeedData()
  {
    HashSet<User> users = [];
    String localPath = @"Files\Users.txt";
    if (!File.Exists(localPath))
    {
      return users;
    }
    foreach (var item in File.ReadAllLines(localPath))
    {
      String[] lineParts = item.Split(';');
      User user = new()
      {
        Id = Guid.NewGuid(),
        UserName = lineParts[0],
        Name = lineParts[1],
        LastName = lineParts[2],
        Birthday = lineParts[3] == "" ? null : DateTime.Parse(lineParts[3]),
        Email = lineParts[4],
        NormalizedEmail = lineParts[4].ToUpper(),
        EmailConfirmed = lineParts[5] != "" && bool.Parse(lineParts[5]),
        LockoutEnabled = bool.Parse(lineParts[6]),
        PhoneNumber = lineParts[7],
        PhoneNumberConfirmed = bool.Parse(lineParts[8])
      };
      users.Add(user);
    }
    return users;
  }
}