using Application.Core;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    // add identity 
    services.AddIdentityCore<User>(
              opt => opt.Password.RequireNonAlphanumeric = false)
            .AddEntityFrameworkStores<DataContext>()
            .AddSignInManager<SignInManager<User>>();
    services.AddAutoMapper(typeof(MappingProfiles).Assembly);
    services.AddMediatR(typeof(DependencyInjection).Assembly);

    return services;
  }
}