namespace SneakerServer;
public static class ServiceExtensions
{
  public static IServiceCollection AddDatabaseServices(this IServiceCollection services, ConfigurationManager configuration)
  {
    services.AddDbContext<SneakerContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("SneakerDatabase")).ConfigureWarnings
        (warnings =>
        {
          // Necessary for seeding identity in EF Core 9
          warnings.Log(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning);
        }));

    return services;
  }

  public static IServiceCollection AddBaseServices(this IServiceCollection services)
  {
    services.AddControllers();
    services.AddOpenApi();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddMvc()
      .AddJsonOptions(
        options => options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
        );
    return services;
  }

  public static IServiceCollection AddAuthServices(this IServiceCollection services)
  {
    services.AddAuthorization();
    // builder.Services
    //   .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    //     .AddCookie(options =>
    //     {
    //       options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    //     });

    services.AddIdentityCore<User>()
            .AddEntityFrameworkStores<SneakerContext>();
    services.AddIdentityApiEndpoints<User>()
        .AddEntityFrameworkStores<SneakerContext>();

    // builder.Services.AddDbContext<IdentityDbContext>(
    //     options => options.UseInMemoryDatabase("AppDb"));
    return services;
  }
}