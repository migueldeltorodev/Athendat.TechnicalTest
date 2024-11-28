using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Users.Api.Database;
using Users.Api.Repositories;
using FastEndpoints;
using FastEndpoints.Swagger;
using Users.Api.Services;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

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
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();

app.UseOpenApi();
app.UseSwaggerUi(s => s.ConfigureDefaults());

app.UseHttpsRedirection();

//var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
//await databaseInitializer.InitializeAsync();

app.Run();