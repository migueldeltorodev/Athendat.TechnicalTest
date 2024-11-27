using Identity.Api;
using Microsoft.AspNetCore.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<TokenGenerator>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapPost("/login", (LoginRequest request, TokenGenerator tokenGenerator) =>
{
    return new
    {
        access_token = tokenGenerator.GenerateToken(request.Email)
    };
});

app.Run();