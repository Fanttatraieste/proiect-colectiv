using ProiectColectiv.Persistence;
using Microsoft.EntityFrameworkCore;
using ProiectColectiv.Common.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ProiectColectiv.Web.Bootstrap;

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
   .AddEnvironmentVariables()
   .AddUserSecrets<Program>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ProiectColectivDbContext>((sp, options) =>
{
    options.UseSqlServer(connectionString);
});

IConfigurationSection jwtSettings = builder.Configuration.GetSection("jwtConfig");
string jwtSecret = jwtSettings["secret"];

JwtConfig jwtConfig = new()
{
    Audience = jwtSettings["validAudience"],
    ExpiresIn = Convert.ToDouble(jwtSettings["expiresIn"]),
    Issuer = jwtSettings["validIssuer"],
    Secret = jwtSettings["secret"]
};

builder.Services.RegisterWebAPIServices();

builder.Services
    .AddAuthentication(opt =>
    {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["validIssuer"],
            ValidAudience = jwtSettings["validAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
        };
    });

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
