using System.Net;
using System.Net.Http;
using API.Features.Queries.Activities;
using FluentAssertions;
using MediatR;
using Tests.IntegrationTests.Common;

namespace Tests.IntegrationTests.Activities;

public class GetActivitiesTests : IntegrationTest
{
    // private readonly IMediator _mediator;
    // public GetActivitiesTests(IMediator mediator)
    // {
    //     _mediator = mediator;
    // }

    // [Fact]
    // public async Task GetActivities_DefaultActivites_ReturnsActivitiesList()
    // {
    //     // call the GetActivities mediatR handler
    //     var response = await _mediator.Send(new GetActivitiesQuery());

    //     response.Should().NotBeNull();

    //     // // act
    //     // var response = await TestClient.GetAsync("/activities");

    //     // // assert
    //     // response.StatusCode.Should().Be(HttpStatusCode.OK);
    // }
}