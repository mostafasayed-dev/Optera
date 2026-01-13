var builder = WebApplication.CreateBuilder(args);

// Add Redis cache
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379"; // Redis server
    options.InstanceName = "CacheService_";
});

builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();
app.Run();
