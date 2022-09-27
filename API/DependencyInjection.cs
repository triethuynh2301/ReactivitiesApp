using Application.Activities.Commands;
using FluentValidation.AspNetCore;

namespace Api;

public static class DependencyInjection
{
  public static IServiceCollection AddPresentation(this IServiceCollection services)
  {
    services.AddControllers();
    services.AddFluentValidation(
        cfg => cfg.RegisterValidatorsFromAssemblyContaining<Create>());
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
    return services;
  }
}