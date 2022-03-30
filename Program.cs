global using MinimalApi.Data;
global using MinimalApi.Domain.Entities;
global using MinimalApi.Domain.Dtos;
global using MinimalApi.Domain.Interfaces;
global using MinimalApi.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Dependency injection
builder.Services.AddDbContext<AppDataContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Domain Service - Dependency injection
builder.Services.AddScoped<ISaveMarketItem, SaveMarketItem>();
builder.Services.AddScoped<IDeleteMarketItem, DeleteMarketItem>();
builder.Services.AddScoped<IGetMarketItem, GetMarketItem>();

var app = builder.Build();

// Swagger Configuration
app.UseSwagger();
app.UseSwaggerUI();

// Endpoint
app.MapGet("/v1/marketlist", (IGetMarketItem service) => service.GetAll());
app.MapGet("/v1/marketlist/{id}", (Guid id, IGetMarketItem service) => service.GetById(id));
app.MapPost("/v1/marketlist", (MarketItemDTO dto, ISaveMarketItem service) => service.Save(dto));
app.MapDelete("/v1/marketlist/{id}", (Guid id, IDeleteMarketItem service) => service.Delete(id));

app.Run();
