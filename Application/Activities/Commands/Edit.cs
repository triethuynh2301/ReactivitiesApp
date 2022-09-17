using System.Net;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Commands;

public static class Edit
{
  public class Command : IRequest
  {
    public Activity Activity { get; set; } = null!;
  }

  public class Handler : IRequestHandler<Command>
  {
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public Handler(DataContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
    {
      var activity = await _context.Activities.FindAsync(request.Activity.Id);

      if (activity == null)
        throw new Exception("Could not find activity");

      // map the request to entity
      _mapper.Map(request.Activity, activity);

      var success = await _context.SaveChangesAsync(cancellationToken) > 0;

      if (success) return Unit.Value;

      throw new Exception("Problem saving changes");
    }
  }
}