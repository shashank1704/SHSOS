using Microsoft.EntityFrameworkCore;
using SHSOS.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registers EF Core with SQL Server
builder.Services.AddDbContext<SHSOSDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SHSOS"))
);

// Allow front-end origin(s) during development — replace with your front-end origin(s)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.AllowAnyMethod()
              .AllowAnyHeader()
              .WithOrigins("http://localhost:3000", "https://localhost:3001"));
});

var app = builder.Build();

// Enable Swagger UI unconditionally and serve it at the application root so opening the browser shows the UI.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SHSOS API v1");
    c.RoutePrefix = string.Empty; // Serve Swagger UI at "/" for quick testing
});

app.UseCors("AllowFrontend");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<SHSOSDb>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//```
// dotnet restore
// dotnet build
//```
