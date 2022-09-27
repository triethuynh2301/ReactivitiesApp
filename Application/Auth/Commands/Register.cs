using Application.Core;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Auth.Commands;

public static class Register
{
  public class Command : IRequest<Result<Unit>>
  {
    public string DisplayName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
  }

  public class Handler : IRequestHandler<Command, Result<Unit>>
  {
    private readonly UserManager<User> _userManager;
    public Handler(UserManager<User> userManager)
    {
      _userManager = userManager;
    }
    public Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
