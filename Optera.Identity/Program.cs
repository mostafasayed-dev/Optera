using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Optera.Identity;
using Optera.Identity.JWT;
using Optera.Identity.Repositories;
using Optera.Identity.Repositories.Interfaces;
using Optera.Identity.Services;
using Optera.Identity.Services.Interfaces;
using Optera.Shared.Identity;
using Serilog;
using Serilog.Formatting.Compact;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.AddEntityFrameworkOutbox<AppDbContext>(o =>
    {
        o.UseSqlServer();
        o.QueryDelay = TimeSpan.FromSeconds(1); // check for new messages every second
        o.UseBusOutbox();
    });
    // auto-register consumers
    //x.AddConsumersFromNamespaceContaining<YourConsumer>();
    //http://localhost:15672
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMq:Host"], "/", h =>
        {
            h.Username(builder.Configuration["RabbitMq:Username"]!);
            h.Password(builder.Configuration["RabbitMq:Password"]!);
        });

        cfg.ConfigureEndpoints(context); // automatically configure endpoints for consumers
    });
});

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .WriteTo.File(
        new CompactJsonFormatter(),
        "Logs/log-.json",
        rollingInterval: RollingInterval.Day,
        retainedFileCountLimit: 30,
        shared: true)
    .WriteTo.Seq("http://localhost:5341")
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IAuthRepository<IdentityUser, IdentityRole>, AuthRepository<IdentityUser, IdentityRole>>();
builder.Services.AddScoped<IAuthService, AuthService<IdentityUser, IdentityRole>>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserContext, CurrentUserContext>();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
        ValidAudience = builder.Configuration["Jwt:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!)),
        ClockSkew = TimeSpan.Zero // no extra tolerance
    };
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Optera Identity API", Version = "v1" });

    // Add JWT Bearer Authorization
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT token like: Bearer {your token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Configure CORS to allow designer app hosted on a different origin to invoke the APIs.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(cors => cors
    //.AddDefaultPolicy(policy => policy
    .AddPolicy(MyAllowSpecificOrigins, policy => policy
        //.AllowAnyOrigin() // For demo purposes only. Use a specific origin instead.
        .WithOrigins("https://localhost:7072")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .WithExposedHeaders("x-elsa-workflow-instance-id"))); // Required for Elsa Studio in order to support running workflows from the designer. Alternatively, you can use the `*` wildcard to expose all headers.




var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        // Run Database Migrations
        dbContext.Database.Migrate();

        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //Create Roles
        var roles = new[] { "Admin" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        var admin = await userManager.FindByNameAsync("admin");
        if (admin == null)
        {
            admin = new IdentityUser
            {
                UserName = "admin",
                Email = "admin@optera.com",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(admin, "P@ssw0rd");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Admin");
                //User Claims
                var claims = new[]
                {
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.Sub, admin.Id),
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.UniqueName, admin.UserName),
                    new System.Security.Claims.Claim("permissions", "*"),
                };
                foreach (var claim in claims)
                {
                    await userManager.AddClaimAsync(admin, claim);
                }
            }
        }

        //var services = scope.ServiceProvider;
        //var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        //const string adminRoleName = "Admin";

        //if (!await roleManager.RoleExistsAsync(adminRoleName))
        //{
        //    var result = await roleManager.CreateAsync(new IdentityRole(adminRoleName));
        //    if (result.Succeeded)
        //    {
        //        //Console.WriteLine($"Role '{adminRoleName}' created.");
        //        Log.Information("Role '{Role}' created.", adminRoleName);
        //    }
        //    else
        //    {
        //        //Console.WriteLine($"Failed to create role '{adminRoleName}': " +
        //        //                  string.Join(", ", result.Errors.Select(e => e.Description)));

        //        Log.Warning("Failed to create role '{Role}': {Errors}", adminRoleName,
        //                    string.Join(", ", result.Errors.Select(e => e.Description)));
        //    }
        //}
        //else
        //{
        //    //Console.WriteLine($"Role '{adminRoleName}' already exists.");
        //    Log.Warning("Role '{Role}' already exists.", adminRoleName);
        //}
    }
    catch (Exception ex)
    {
        // Log migration failure
        Console.WriteLine($"Migration failed: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Optera Identity v1");
        c.RoutePrefix = string.Empty; // Opens Swagger at root
    });
}

app.UseCors(MyAllowSpecificOrigins);

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
