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

// AI-generated home page for testing purposes - is not in project scope
app.MapGet("/", () =>
{
    var html = """
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Plants API</title>
        <style>
            body {
                font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
                margin: 0;
                padding: 0;
                display: flex;
                justify-content: center;
                align-items: center;
                min-height: 100vh;
                color: #333;
            }
            .container {
                background: white;
                border-radius: 20px;
                padding: 40px 60px;
                box-shadow: 0 20px 60px rgba(0,0,0,0.3);
                max-width: 600px;
                text-align: center;
            }
            h1 {
                color: #667eea;
                margin-bottom: 10px;
                font-size: 2.5em;
            }
            .version {
                color: #999;
                font-size: 0.9em;
                margin-bottom: 30px;
            }
            p {
                line-height: 1.6;
                color: #555;
                margin-bottom: 30px;
            }
            .links {
                display: flex;
                gap: 15px;
                justify-content: center;
                flex-wrap: wrap;
            }
            a {
                display: inline-block;
                padding: 12px 30px;
                background: #667eea;
                color: white;
                text-decoration: none;
                border-radius: 8px;
                transition: all 0.3s ease;
                font-weight: 600;
            }
            a:hover {
                background: #764ba2;
                transform: translateY(-2px);
                box-shadow: 0 5px 15px rgba(0,0,0,0.2);
            }
            .emoji {
                font-size: 3em;
                margin-bottom: 20px;
            }
            .info {
                background: #f8f9fa;
                padding: 20px;
                border-radius: 10px;
                margin-top: 30px;
                font-size: 0.9em;
            }
            .info-item {
                margin: 10px 0;
                color: #666;
            }
        </style>
    </head>
    <body>
        <div class="container">
            <div class="emoji">🌿</div>
            <h1>Plants API</h1>
            <div class="version">v1.0.0</div>
            <p>
                Welcome to the Plants API! This API helps you manage your plant collection 
                with information about watering schedules, species, and planting dates.
            </p>
            <div class="links">
                <a href="/swagger">📚 API Documentation</a>
                <a href="/api/plants">🌱 View Plants</a>
                <a href="/api/version">ℹ️ Version Info</a>
            </div>
            <div class="info">
                <div class="info-item">🏗️ Built with .NET 9 & Minimal APIs</div>
                <div class="info-item">🐳 Containerized with Docker</div>
                <div class="info-item">☁️ Deployed on Azure App Service</div>
                <div class="info-item">🚀 CI/CD with GitHub Actions</div>
            </div>
        </div>
    </body>
    </html>
    """;
    
    return Results.Content(html, "text/html");
})
.WithName("HomePage")
.ExcludeFromDescription();

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