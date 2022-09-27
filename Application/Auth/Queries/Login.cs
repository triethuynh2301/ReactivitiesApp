using Application.Auth.Common;
using Application.Common.Interfaces;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Auth.Queries;

public static class Login
{
  public class Query : IRequest<Result<UserResult>?>
  {
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
  }

  public class Handler : IRequestHandler<Query, Result<UserResult>?>
  {
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IJwtTokenGenerator _jwtGenerator;

    public Handler(
      UserManager<User> userManager,
      SignInManager<User> signInManager,
      IJwtTokenGenerator jwtGenerator
    )
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _jwtGenerator = jwtGenerator;
    }

    public async Task<Result<UserResult>?> Handle(Query request, CancellationToken cancellationToken)
    {
      // find user by email
      var user = await _userManager.FindByEmailAsync(request.Email);

      // if user not found -> return null
      if (user == null) return null;

      // verify password if found
      var result = await _signInManager.CheckPasswordSignInAsync(
        user, request.Password, false);

      // if auth failed -> return null
      if (!result.Succeeded) return null;

      // if auth succeed -> return user
      return Result<UserResult>.Success(new UserResult
      {
        DisplayName = user.DisplayName,
        // generate token for the user
        Token = _jwtGenerator.GenerateToken(user),
        Username = user.UserName,
        Image = "image"
      });
    }
  }
}
