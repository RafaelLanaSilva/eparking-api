using Eparking.API.Configuration;
using Eparking.Domain.Contracts.Repositories;
using Eparking.Domain.Contracts.Services;
using Eparking.Domain.Mappings;
using Eparking.Domain.Services;
using Eparking.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(map => { map.LowercaseUrls = true; });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

SwaggerConfiguration.AddSwaggerConfiguration(builder.Services);
CorsConfiguration.AddCorsConfiguration(builder.Services);
DependencyInjectionConfiguration.AddDependencyInjection(builder.Services);

var app = builder.Build();

SwaggerConfiguration.UseSwaggerConfiguration(app);
CorsConfiguration.UseCorsConfiguration(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
