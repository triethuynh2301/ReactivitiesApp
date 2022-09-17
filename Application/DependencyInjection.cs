using Application.Core;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddAutoMapper(typeof(MappingProfiles).Assembly);
    services.AddMediatR(typeof(DependencyInjection).Assembly);
    return services;
  }
}