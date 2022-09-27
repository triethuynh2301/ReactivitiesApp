using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Queries;

public static class Find
{
  public class Query : IRequest<Result<Activity>>
  {
    public Guid Id { get; set; }
  }

  public class Handler : IRequestHandler<Query, Result<Activity>>
  {
    private readonly DataContext _context;

    public Handler(DataContext context)
    {
      _context = context;
    }
    public async Task<Result<Activity>> Handle(Query request, CancellationToken cancellationToken)
    {
      // find the activity by id
      var activity = await _context.Activities.FindAsync(request.Id);

      // success if no errors even if activity is null
      return Result<Activity>.Success(activity);
    }
  }
}