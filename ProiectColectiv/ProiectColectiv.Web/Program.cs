using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProiectColectiv.Application.Bootstrap;
using ProiectColectiv.Common.Config;
using ProiectColectiv.Persistence;
using ProiectColectiv.Persistence.Bootstrap;
using ProiectColectiv.Web.Bootstrap;
using ProiectColectiv.Web.Filters;
using System.Text;
using ProiectColectiv.Application.Commands.SpecializationCommands;
using ProiectColectiv.Application.Queries.SpecializationQueries;
using ProiectColectiv.Domain.Repositories;
using ProiectColectiv.Persistence.Repositories.Base;

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

// caca maca

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

//builder.Services.RegisterInfrastructureComponents();
builder.Services.RegisterApplicationServices();
builder.Services.RegisterRepositories();
builder.Services.RegisterWebAPIServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    //options.EnableAnnotations();
    options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`. You need to execute one of the Login methods to get the token.",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Name = "Bearer",
                In = ParameterLocation.Header,
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});


builder.Services.AddSingleton(jwtConfig);
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddScoped(x =>
{
    ActionContext? actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
    IUrlHelperFactory factory = x.GetRequiredService<IUrlHelperFactory>();
    return factory.GetUrlHelper(actionContext);
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Logging.AddFilter("Microsoft", LogLevel.Warning);

builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Error);

builder.Logging.AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Warning);

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

builder.Services.AddControllers(options => options.Filters.Add<CustomExceptionFilterAttribute>());

// Register your handlers as scoped or transient services
builder.Services.AddScoped<SpecializationCommandHandler>();

builder.Services.AddScoped<SpecialisationsQueryHandler>();

// Also register repositories if they are used in handlers
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
