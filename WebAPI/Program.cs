using System.Security.Claims;
using Business;
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Models;

string AllowedSpecificOrigins = "_allowedSpecificOrigins";

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services
  .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
  {
    TokenOption tokenOption = builder.Configuration.GetSection("TokenOption").Get<TokenOption>();

    options.TokenValidationParameters = new TokenValidationParameters()
    {
      RoleClaimType = ClaimTypes.Role,
      ValidateAudience = true,
      ValidateIssuer = true,
      ValidateLifetime = true,
      ValidateIssuerSigningKey = true,
      ValidIssuer = tokenOption.Issuer,
      ValidAudience = tokenOption.Audience,
      IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(tokenOption.Key))
    };
  });

builder.Services.AddBusinessLogic();
builder.Services.AddDataAccess(builder.Configuration);

builder.Services.AddCors(options =>
{
  options.AddPolicy(AllowedSpecificOrigins, policy =>
  {
    policy.WithOrigins("http://localhost:3000", "https://localhost:7252");
    policy.WithMethods("POST", "GET", "DELETE", "PUT", "PATCH");
    policy.AllowAnyHeader();
  });
});

builder.Services.AddControllers();

WebApplication app = builder.Build();

app.UseCors(AllowedSpecificOrigins);

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoint => endpoint.MapControllers());

app.Run();
