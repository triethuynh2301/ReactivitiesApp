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

namespace API.Features.Activities.Commands;

// controllers
[Route("api/activities")]
public class UpdateActivityController : ApiController
{
    private readonly IMediator _mediator;
    public UpdateActivityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateActivity(Guid id, UpdateActivityCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);

        return result.Match(
            _ => NoContent(),
            errors => Problem(errors));
    }
}
// command
public class UpdateActivityCommand : IRequest<ErrorOr<Unit>>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.Now;
    public string City { get; set; } = string.Empty;
    public string Venue { get; set; } = string.Empty;
}
// validation
public class UpdateActivityCommandValidator : AbstractValidator<UpdateActivityCommand>
{
    public UpdateActivityCommandValidator()
    {
        // at least one property must be provided
        RuleFor(x => x).Must(x => !string.IsNullOrWhiteSpace(x.Title)
                                    || !string.IsNullOrWhiteSpace(x.Description)
                                    || !string.IsNullOrWhiteSpace(x.Category)
                                    || !string.IsNullOrWhiteSpace(x.City)
                                    || !string.IsNullOrWhiteSpace(x.Venue)).WithMessage("At least one property must be provided");
    }
}
// mapping
public class UpdateActivityProfile : Profile
{
    public UpdateActivityProfile()
    {
        // only map non null values
        CreateMap<UpdateActivityCommand, Activity>()
            .ForAllMembers(
                x => x.Condition((_, _, srcMember) => !string.IsNullOrWhiteSpace(srcMember.ToString())));
    }
}
// handler
public class UpdateActivityHandler : IRequestHandler<UpdateActivityCommand, ErrorOr<Unit>>
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public UpdateActivityHandler(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = await _context.Activities.SingleOrDefaultAsync(
            x => x.Id == request.Id,
            cancellationToken);
        if (activity is null)
        {
            return ActivityErrors.NotFound;
        }

        _mapper.Map(request, activity);

        var result = await _context.SaveChangesAsync(cancellationToken) > 0;
        if (!result)
        {
            return ActivityErrors.DatabaseError;
        }

        return Unit.Value;
    }
}