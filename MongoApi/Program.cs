using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using MongoDataLibrary.Configuration;
using MongoDataLibrary.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configure CORS
const string apiCorsPolicy = "_apiAllowedOrigins";
builder.Services.AddCors(options =>
{
    string allowedOrigin = builder.Configuration.GetValue("AllowedOrigin", "")!;
    options.AddPolicy(name: apiCorsPolicy,
        builder =>
        {
            builder.WithOrigins(allowedOrigin)
            .WithMethods("GET", "OPTIONS")
            .AllowAnyHeader();
        });
});

// Instantiate MongoDBSettings class with appsetting.json parameters, which then will be injected into MongoDataService
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection(MongoDBSettings.MongoDBSection));

// Create singleton MongoDataService instance, which then will be injected into PlanetsController
builder.Services.AddSingleton<IMongoDataService, MongoDataService>();

// Enable controllers (not minimalAPI)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configure Swagger with XML documentation. This requires also adding a few lines into .csproj file.
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(apiCorsPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

