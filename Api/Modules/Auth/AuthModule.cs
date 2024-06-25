using Module.Interfaces;
using Api.Modules.Auth.Endpoints;

namespace Api.Modules.Auth;

internal sealed class AuthModule : IEndpointModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/AuthApi").WithTags("AuthModule");

        group.MapPost("/GetToken", GetToken.Handler)
            .WithOpenApi();

        return group;
    }
}
