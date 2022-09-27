using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Activities.Commands;

public static class Edit
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
  public class Handler : IRequestHandler<Command, Result<Unit>?>
  {
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public Handler(DataContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<Result<Unit>?> Handle(Command request, CancellationToken cancellationToken)
    {
      var activity = await _context.Activities.FindAsync(request.Activity.Id);

      // activity not found -> return null
      if (activity == null) return null;

      // map the request to entity
      _mapper.Map(request.Activity, activity);

      // check if any operation is committed to db
      var success = await _context.SaveChangesAsync(cancellationToken) > 0;

      // if no operation is committed -> failure
      if (!success) return Result<Unit>.Failure("Failed to edit activity");

      return Result<Unit>.Success(Unit.Value);
    }
  }
}