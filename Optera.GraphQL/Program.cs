using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Optera.GraphQL.DataLoaders;
using Optera.GraphQL.Handlers;
using Optera.GraphQL.Models;
using Optera.GraphQL.Queries;
using Optera.GraphQL.Services;
using Optera.GraphQL.Services.Interfaces;
using Optera.GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<JwtForwardingHandler>();

builder.Services.AddHttpClient<IUserService, UserService>(client =>
{
    var baseAddress = configuration["HttpClients:IdentityService:BaseAddress"];
    client.BaseAddress = new Uri(baseAddress!);
}).AddHttpMessageHandler<JwtForwardingHandler>();

builder.Services.AddHttpClient<IConfigurationService, ConfigurationService>(client =>
{
    var baseAddress = configuration["HttpClients:ConfigurationService:BaseAddress"];
    client.BaseAddress = new Uri(baseAddress!);
}).AddHttpMessageHandler<JwtForwardingHandler>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
            ValidAudience = builder.Configuration["Jwt:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!)
            ),
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
    .AddTypeExtension<UserQuery>()
    .AddTypeExtension<ConfigurationQuery>()
    .AddType<UserType>()
    .AddType<ComponentType>()
    .AddType(typeof(ServiceResponseType<User>))
    .AddDataLoader<UserByIdDataLoader>()
    .AddFiltering()
    .AddSorting()
    .AddProjections()
    .AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapGraphQL();

app.Run();

