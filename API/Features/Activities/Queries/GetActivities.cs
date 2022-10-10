using API.Domain;
using API.Infrastructure.Persistence;
using AutoMapper;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reactivities.API.Controllers;

namespace API.Features.Queries.Activities;

// controllers
[Route("api/activities")]
public class GetActivitiesController : ApiController
{
    private readonly IMediator _mediator;
    public GetActivitiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetActivities()
    {
        var result = await _mediator.Send(new GetActivitiesQuery());

        return result.Match(
            activities => Ok(activities),
            errors => Problem(errors));
    }
}
// query
public class GetActivitiesQuery : IRequest<ErrorOr<List<GetActivitiesResponse>>> { }
// response
public class GetActivitiesResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.Now;
    public string City { get; set; } = string.Empty;
    public string Venue { get; set; } = string.Empty;
}
// mapping
public class GetActivitiesProfile : Profile
{
    public GetActivitiesProfile()
    {
        CreateMap<Activity, GetActivitiesResponse>();
    }
}
// handler
public class GetActivitiesHandler : IRequestHandler<GetActivitiesQuery, ErrorOr<List<GetActivitiesResponse>>>
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    public GetActivitiesHandler(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<ErrorOr<List<GetActivitiesResponse>>> Handle(GetActivitiesQuery request, CancellationToken cancellationToken)
    {
        // get all activities
        var activities = await _context.Activities.ToListAsync(cancellationToken: cancellationToken);

        // map to response
        return _mapper.Map<List<GetActivitiesResponse>>(activities);
    }
}