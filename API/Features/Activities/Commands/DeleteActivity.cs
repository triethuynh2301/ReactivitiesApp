using API.Common.Errors;
using API.Infrastructure.Persistence;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reactivities.API.Controllers;

namespace API.Features.Activities.Commands;

// controllers
[Route("api/activities")]
public class DeleteActivityController : ApiController
{
    private readonly IMediator _mediator;
    public DeleteActivityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivity(Guid id)
    {
        var result = await _mediator.Send(new DeleteActivityCommand { Id = id });

        return result.Match(
            _ => Ok(),
            errors => Problem(errors));
    }
}
// query
public class DeleteActivityCommand : IRequest<ErrorOr<Unit>>
{
    public Guid Id { get; set; }
}
// handler
public class DeleteActivityHandler : IRequestHandler<DeleteActivityCommand, ErrorOr<Unit>>
{
    private readonly DataContext _context;
    public DeleteActivityHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = await _context.Activities.SingleOrDefaultAsync(
            x => x.Id == request.Id,
            cancellationToken);

        if (activity is null)
        {
            return ActivityErrors.NotFound;
        }

        _context.Activities.Remove(activity);

        var result = await _context.SaveChangesAsync(cancellationToken) > 0;

        if (!result)
        {
            return ActivityErrors.DatabaseError;
        }

        return Unit.Value;
    }
}