using API.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests.IntegrationTests.Common;

public class IntegrationTest
{
    protected readonly HttpClient TestClient;

    public IntegrationTest()
    {
        var clientOptions = new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = true,
            BaseAddress = new Uri("https://localhost:5000"),
            HandleCookies = true,
            MaxAutomaticRedirections = 7
        };
        TestClient = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // services.AddDbContext<DataContext>(options =>
                    // {
                    //     options.UseInMemoryDatabase("TestDb");
                    // });
                });
            })
            .CreateClient(clientOptions);
    }
}