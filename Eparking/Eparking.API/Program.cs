using Eparking.Domain.Contracts.Repositories;
using Eparking.Domain.Contracts.Services;
using Eparking.Domain.Mappings;
using Eparking.Domain.Services;
using Eparking.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(ProfileMap));

// Add Dependency Injection
builder.Services.AddTransient<IEstacionamentoService, EstacionamentoDomainService>();
builder.Services.AddTransient<IEstacionamentoRepository, EstacionamentoRepository>();
builder.Services.AddTransient<IVeiculoService, VeiculoDomainService>();
builder.Services.AddTransient<IVeiculoRepository, VeiculoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
