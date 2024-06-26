using Api.Modules.Devices.Endpoints;
using Module.Interfaces;

namespace Api.Modules.Devices;

internal sealed class DevicesModule : IEndpointModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/DevicesApi").WithTags("DevicesModule");

        group.MapPost("/GetDevices", GetDevices.Handler)
            .WithOpenApi();

        return group;
    }
}
