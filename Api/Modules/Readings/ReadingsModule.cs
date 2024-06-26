using Api.Modules.Readings.Endpoints;
using Module.Interfaces;

namespace Api.Modules.Readings;

internal sealed class ReadingsModule : IEndpointModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/ReadingsApi").WithTags("ReadingsModule");

        group.MapPost("/Location", LocationReadings.Handler)
            .WithOpenApi();

        group.MapPost("/LtGeo", LTGeoReadings.Handler)
            .WithOpenApi();

        return group;
    }
}
