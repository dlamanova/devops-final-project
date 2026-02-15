using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Plants API",
        Version = "v1",
        Description = "API for managing plants with C# and ASP.NET Core"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Plants API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/api/version", () =>
{
    var version = typeof(Program).Assembly
        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
        .InformationalVersion ?? "1.0.0";
    
    var gitCommit = Environment.GetEnvironmentVariable("GIT_COMMIT") ?? "unknown";
    var buildDate = Environment.GetEnvironmentVariable("BUILD_DATE") ?? DateTime.UtcNow.ToString("o");
    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

    return Results.Ok(new
    {
        version,
        gitCommit,
        buildDate,
        environment,
        applicationName = "Plants API"
    });
})
.WithName("GetVersion")
.WithTags("Info")
.Produces<object>(StatusCodes.Status200OK);

app.Run();