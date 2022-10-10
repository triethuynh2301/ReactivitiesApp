using System.Reflection;
using System.Text;
using API.Domain;
using API.Infrastructure.Persistence;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddFluentValidation(
            cfg => cfg.RegisterValidatorsFromAssemblyContaining<Program>());
        services.AddEndpointsApiExplorer();
        services.AddAuthentication();
        services.AddSwaggerGen();
        // configure CORS
        services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", policy =>
                    {
                        policy.WithOrigins("http://localhost:5173")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                    });
        });

        // add identity
        services.AddIdentityCore<User>(
                  opt => opt.Password.RequireNonAlphanumeric = false)
                .AddEntityFrameworkStores<DataContext>()
                .AddSignInManager<SignInManager<User>>();
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        services.AddMediatR(Assembly.GetExecutingAssembly());

        // services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        // add authentication
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
            options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("super secret key")),
                ValidateIssuer = false,
                ValidateAudience = false
            });

        // EF Core
        services.AddDbContext<DataContext>(opt => opt.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }
}