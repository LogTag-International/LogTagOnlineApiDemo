using Api.Modules.Shipments.Endpoints;
using Module.Interfaces;

internal sealed class ShipmentsModule : IEndpointModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/ShipmentsApi").WithTags("ShipmentsModule");

        group.MapPost("/Shipments", Shipments.Handler).WithOpenApi();

        return group;
    }
}
