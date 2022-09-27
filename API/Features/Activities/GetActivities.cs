using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Features.Activities;

// controllers
public class GetActivitiesController : ControllerBase
{
    private readonly IMediator _mediator;
    public GetActivitiesController(IMediator mediator)
    {
        _mediator = mediator;
    }
}

// query
public class GetActivitiesQuery : IRequest<Result<GetActivitiesResponse>>
{
}

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