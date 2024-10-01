using Bike.Domain.Adapters;
using Bike.Domain.Ports;
using BikeApi.Client.Client;
using BikeApi.Client;
using Serilog;
using Bike.Api;
using Microsoft.OpenApi.Models;
using Bike.Domain.Models;
using Bike.Api.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var apiSettings = builder.Configuration.GetSection("ApiSettings").Get<ApiSettings>();
var logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

builder.Services.AddSingleton(new BikeApiClientFactory(apiSettings.ApplicationName, MapToClientSettings(apiSettings.BikeApiSettings), logger));
builder.Services.AddScoped<IThreftBikesCountClient>(provider =>
{
    var factory = provider.GetRequiredService<BikeApiClientFactory>();
    return factory.CreateThreftBikesCountClient();
});
builder.Services.AddScoped<IBikeService, BikeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

BikeApi.Client.BikeApiSettings MapToClientSettings(Bike.Api.BikeApiSettings settings)
{
    return new BikeApi.Client.BikeApiSettings
    {
        BaseUri = settings.BaseUri,
        ThreftBikesRelativeUri = settings.ThreftBikesRelativeUri,
        ThreftBikesCountRelativeUri = settings.ThreftBikesCountRelativeUri
    };
}