var builder = WebApplication.CreateBuilder(args);

builder.Services
  .AddBaseServices()
  .AddDatabaseServices(builder.Configuration)
  .AddAuthServices();

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

app.MapIdentityApi<User>();

app.Run();