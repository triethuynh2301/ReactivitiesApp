using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities.Queries;

public static class List
{
  public class Query : IRequest<Result<List<Activity>>> { }

  public class Handler : IRequestHandler<Query, Result<List<Activity>>>
  {
    private readonly DataContext _context;

    public Handler(DataContext context)
    {
      _context = context;
    }

    public async Task<Result<List<Activity>>> Handle(Query request, CancellationToken cancellationToken)
    {
      // get all activities
      var res = await _context.Activities.ToListAsync(cancellationToken: cancellationToken);

      // success if no errors regardless even if then list is empty
      return Result<List<Activity>>.Success(res);
    }
  }
}