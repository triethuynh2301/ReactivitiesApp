using API.Common.Errors;
using API.Domain;
using API.Infrastructure.Persistence;
using AutoMapper;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reactivities.API.Controllers;

namespace API.Features.Queries.Activities;

// controllers
[Route("api/activities")]
public class GetActivityController : ApiController
{
    private readonly IMediator _mediator;
    public GetActivityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetActivity(Guid id)
    {
        var result = await _mediator.Send(new GetActivityQuery { Id = id });

        return result.Match(
            activity => Ok(activity),
            errors => Problem(errors));
    }
}
// query
public class GetActivityQuery : IRequest<ErrorOr<GetActivityResponse>>
{
    public Guid Id { get; set; }
}
// validation
public class GetActivityQueryValidator : AbstractValidator<GetActivityQuery>
{
    public GetActivityQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
// response
public class GetActivityResponse
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
public class GetActivityProfile : Profile
{
    public GetActivityProfile()
    {
        CreateMap<Activity, GetActivityResponse>();
    }
}
// handler
public class GetActivityHandler : IRequestHandler<GetActivityQuery, ErrorOr<GetActivityResponse>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public GetActivityHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ErrorOr<GetActivityResponse>> Handle(GetActivityQuery request, CancellationToken cancellationToken)
    {
        var activity = await _context.Activities
            .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (activity is null) return ActivityErrors.NotFound;

        return _mapper.Map<Activity, GetActivityResponse>(activity);
    }
}