using Microsoft.AspNetCore.Routing;

namespace Module.Interfaces;

public interface IEndpointModule : IModuleBase
{
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}
