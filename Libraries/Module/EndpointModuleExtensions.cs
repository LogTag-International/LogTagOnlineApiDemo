using Microsoft.AspNetCore.Builder;
using Module.Interfaces;
using System.Reflection;

namespace Module;

public static class EndpointModuleExtensions
{
    public static WebApplication MapEndpoints(this WebApplication app, Assembly mainAssembly)
    {
        IEnumerable<IEndpointModule> endpointModules = ModuleDiscovery<IEndpointModule>.DiscoverModules(mainAssembly);
        
        foreach (IEndpointModule endpointModule in endpointModules)        
            endpointModule.MapEndpoints(app);
        
        return app;
    }
}
