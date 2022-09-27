using Application.Core;
using MediatR;
using Persistence;

namespace Application.Activities;

public static class Delete
{
  // request class
  public class Command : IRequest<Result<Unit>>
  {
    public Guid Id { get; set; }
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
      var activity = await _context.Activities.FindAsync(request.Id);

      // if no activity found -> return null
      if (activity == null) return null;

      _context.Remove(activity);

      // check if any operation is committed to db
      var success = await _context.SaveChangesAsync(cancellationToken) > 0;

      // if no operation is committed -> failure
      if (!success) return Result<Unit>.Failure("Failed to delete activity");

      return Result<Unit>.Success(Unit.Value);
    }
  }
}
