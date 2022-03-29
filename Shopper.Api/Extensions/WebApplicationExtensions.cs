using Shopper.Api.Endpoints;

namespace Shopper.Api.Extensions;

public static class WebApplicationExtensions
{
    public static void RegisterEndpoints(this WebApplication app)
    {
        var apis = app.Services.GetServices<IEndpointRouting>();
        foreach (var api in apis)
        {
            if (api is null) throw new InvalidProgramException("Apis not found");

            api.Register(app);
        }
    }
}