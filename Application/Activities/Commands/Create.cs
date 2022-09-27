using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Activities.Commands;

public class Create
{
  // request class
  public class Command : IRequest<Result<Unit>>
  {
    public Activity Activity { get; set; } = null!;
  }

  // request validator
  public class CommandValidator : AbstractValidator<Command>
  {
    public CommandValidator()
    {
      RuleFor(x => x.Activity).SetValidator(new CreateEditValidator());
    }
  }

  // request handler
  public class Handler : IRequestHandler<Command, Result<Unit>>
  {
    private readonly DataContext _context;

    public Handler(DataContext context)
    {
      _context = context;
    }

    public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
    {
      _context.Activities.Add(request.Activity);

      // SaveChangesAsync() returns the number of activities saved to db
      var res = await _context.SaveChangesAsync(cancellationToken: cancellationToken) > 0;

      // if nothing is saved -> failure
      if (!res) return Result<Unit>.Failure("Failed to create activity");

      // specify that operation is complete
      return Result<Unit>.Success(Unit.Value);
    }
  }
}