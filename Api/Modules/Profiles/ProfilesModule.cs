using Api.Modules.Profiles.Endpoints;
using Module.Interfaces;

internal sealed class ProfilesModule : IEndpointModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/ProfilesApi").WithTags("ProfilesModule");

        group.MapPost("/GetProfiles", GetProfiles.Handler).WithOpenApi();

        return group;
    }
}
