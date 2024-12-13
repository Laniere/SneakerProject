var builder = WebApplication.CreateBuilder(args);
string _connectionString = @"Data Source=DESKTOP-7P5OR8C;Initial Catalog=sneakers;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
            {
              options.AddDefaultPolicy(builder =>
              builder.WithOrigins("http://localhost:5282")
                     .AllowAnyMethod()
                     .AllowAnyHeader());
            });

var connectionString =
    builder.Configuration.GetConnectionString(_connectionString);

builder.Services.AddDbContext<SneakerContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
