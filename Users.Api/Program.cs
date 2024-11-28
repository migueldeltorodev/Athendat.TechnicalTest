using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Users.Api.Database;
using Users.Api.Repositories;
using FastEndpoints;
using FastEndpoints.Swagger;
using Users.Api.Services;
using Identity.Api;
using Serilog;
using DotNetEnv;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("starting server...");

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// configurating Serilog
builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration.WriteTo.Console();
    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
});

// getting serilog config
var logPath = Environment.GetEnvironmentVariable("LOG_FILE_PATH");
var serverUrl = Environment.GetEnvironmentVariable("SEQ_SERVER_URL");

builder.Configuration["Serilog:WriteTo:0:Args:path"] = logPath;
builder.Configuration["Serilog:WriteTo:1:Args:serverUrl"] = serverUrl;

// Add services to the container.
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey("ThisIsATechnicalTestForAthendatThatIHopeThatGetMeInto"u8.ToArray()),
            ValidIssuer = "https://id.athendat.com",
            ValidAudience = "https://athendat.com",
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidateIssuer = true,
            ValidateAudience = true,
        };
    });

// FastEndpoints services
builder.Services
    .AddFastEndpoints()
    .SwaggerDocument(o =>
    {
        o.DocumentSettings = s =>
        {
            s.Title = "Users.Api";
            s.Version = "v1";
        };
    });

// Database services
builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
  new MSSQLConnectionFactory(
    builder.Configuration.GetValue<string>("Database:ConnectionString")!));

// TokenGenerator Service
builder.Services.AddSingleton<TokenGenerator>();
// Other services
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSerilogRequestLogging();
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();

app.UseOpenApi();
app.UseSwaggerUi(s => s.ConfigureDefaults());

app.UseHttpsRedirection();

app.Run();