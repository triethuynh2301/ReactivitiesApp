using API.Common.Errors;
using API.Domain;
using API.Infrastructure.Persistence;
using AutoMapper;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reactivities.API.Controllers;

namespace API.Features.Commands.Activities;

// controllers
[Route("api/activities")]
public class CreateActivityController : ApiController
{
    private readonly IMediator _mediator;
    public CreateActivityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivity([FromBody] CreateActivityCommand command)
    {
        var result = await _mediator.Send(command);

        return result.Match(
            activity => Ok(activity),
            errors => Problem(errors));
    }
}
// validation
public class CreateActivityCommandValidator : AbstractValidator<CreateActivityCommand>
{
    public CreateActivityCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Category).NotEmpty();
        RuleFor(x => x.Date).NotEmpty();
    }
}
// query
public class CreateActivityCommand : IRequest<ErrorOr<Unit>>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = null!;
    public DateTime Date { get; set; }
    public string City { get; set; } = string.Empty;
    public string Venue { get; set; } = string.Empty;
}
// mapping
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateActivityCommand, Activity>();
    }
}
// handler
public class CreateActivityHandler : IRequestHandler<CreateActivityCommand, ErrorOr<Unit>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CreateActivityHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Unit>> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = _mapper.Map<Activity>(request);

        _context.Activities.Add(activity);

        var res = await _context.SaveChangesAsync(cancellationToken: cancellationToken) > 0;

        if (!res) return ActivityErrors.DatabaseError;

        return Unit.Value;
    }
}
