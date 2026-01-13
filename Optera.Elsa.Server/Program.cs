using Elsa.EntityFrameworkCore.Extensions;
using Elsa.EntityFrameworkCore.Modules.Management;
using Elsa.EntityFrameworkCore.Modules.Runtime;
using Elsa.Extensions;
using Elsa.Workflows.Api.RealTime.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSignalR();

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Elsa Server API", Version = "v1" });

    c.CustomSchemaIds(type =>
    {
        // Use full name (namespace + type) to avoid collisions
        return type.FullName!.Replace("+", ".");
    });

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

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
    JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();

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
        ClockSkew = TimeSpan.Zero // no extra tolerance
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Elsa", policy =>
    {
        policy.RequireAuthenticatedUser();
        // no role required
    });
});

builder.Services.AddElsa(elsa =>
{
    // Configure Management layer to use EF Core.
    elsa.UseWorkflowManagement(management => management.UseEntityFrameworkCore(ef => ef.UseSqlServer(
        builder.Configuration.GetConnectionString("ElsaConnection")!
        )));

    // Configure Runtime layer to use EF Core.
    elsa.UseWorkflowRuntime(runtime => runtime.UseEntityFrameworkCore(ef => ef.UseSqlServer(
        builder.Configuration.GetConnectionString("ElsaConnection")!
        )));

    // Default Identity features for authentication/authorization.
    //elsa.UseIdentity(identity =>
    //{
    //    identity.TokenOptions = options =>
    //    {
    //        options.SigningKey = "sufficiently-large-secret-signing-key"; // This key needs to be at least 256 bits long.
    //    };
    //    identity.UseAdminUserProvider();
    //});

    // Configure ASP.NET authentication/authorization.
    //elsa.UseDefaultAuthentication(auth => { });

    // Expose Elsa API endpoints.
    elsa.UseWorkflowsApi();

    // Setup a SignalR hub for real-time updates from the server.
    elsa.UseRealTimeWorkflows();

    // Enable C# workflow expressions
    elsa.UseCSharp();

    // Enable JavaScript workflow expressions
    elsa.UseJavaScript(options => options.AllowClrAccess = true);

    // Enable HTTP activities.
    elsa.UseHttp(options => options.ConfigureHttpOptions = httpOptions => httpOptions.BaseUrl = new Uri("https://localhost:7162"));

    // Use timer activities.
    elsa.UseScheduling();

    // Use email activities.
    elsa.UseEmail();

    // Use MassTransit.
    elsa.UseMassTransit();

    elsa.UseLiquid();

    // Register custom activities from the application, if any.
    elsa.AddActivitiesFrom<Program>();

    // Register custom workflows from the application, if any.
    elsa.AddWorkflowsFrom<Program>();

    // Register Webhooks
    elsa.UseWebhooks(webhooks => webhooks.ConfigureSinks += options =>
    builder.Configuration.GetSection("Webhooks")
    .Bind(options)
);
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

// Add Health Checks.
builder.Services.AddHealthChecks();

// Build the web application.
var app = builder.Build();

// Configure web application's middleware pipeline.
app.UseCors(MyAllowSpecificOrigins);
app.UseRouting(); // Required for SignalR.
app.UseAuthentication();
app.UseAuthorization();
app.UseWorkflowsApi(); // Use Elsa API endpoints.
app.UseWorkflows(); // Use Elsa middleware to handle HTTP requests mapped to HTTP Endpoint activities.
//app.UseWorkflowsSignalRHubs(); // Optional SignalR integration. Elsa Studio uses SignalR to receive real-time updates from the server. 

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Elsa Server v1");
        c.RoutePrefix = string.Empty; // Opens Swagger at root
    });
}

// Map the Elsa SignalR hub endpoints.
//app.MapHub<WorkflowInstanceHub>("/elsa/hubs/workflow-instance");

app.MapControllers();

// Optional SignalR integration. Elsa Studio uses SignalR to receive real-time updates from the server. 
app.MapHub<WorkflowInstanceHub>("/elsa/hubs/workflow-instance").AllowAnonymous();

app.Run();