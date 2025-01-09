
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc()
  .AddJsonOptions(
    options => options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
    );
// builder.Services.AddCors(options =>
//             {
//               options.AddDefaultPolicy(builder =>
//               builder.WithOrigins("http://localhost:5282")
//                      .AllowAnyMethod()
//                      .AllowAnyHeader());
//             });
var connectionString =
    builder.Configuration.GetConnectionString("SneakerDatabase");

builder.Services.AddDbContext<SneakerContext>(options =>
    options.UseSqlServer(connectionString).ConfigureWarnings
    (warnings =>
    {
      // Necessary for seeding identity in EF Core 9
      warnings.Log(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning);
    }));


//Setup AUTH
builder.Services.AddAuthorization();
// builder.Services
//   .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//     .AddCookie(options =>
//     {
//       options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
//     });

builder.Services.AddIdentityCore<User>()
        .AddEntityFrameworkStores<SneakerContext>();
builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<SneakerContext>();

// builder.Services.AddDbContext<IdentityDbContext>(
//     options => options.UseInMemoryDatabase("AppDb"));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

//Minimal API TEST
app.MapGet("/brands", async (SneakerContext db) =>
    await db.Set<Brand>().ToListAsync());

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c =>
    {
      c.SwaggerEndpoint("v1/swagger.json", "MyAPI V1");
    });

//AUTH Map Identity Api map these routes
// POST /register
// POST /login
// POST /refresh
// GET /confirmEmail
// POST /resendConfirmationEmail
// POST /forgotPassword
// POST /resetPassword
// POST /manage/2fa
// GET /manage/info
// POST /manage/info 
app.MapIdentityApi<User>();

app.Run();