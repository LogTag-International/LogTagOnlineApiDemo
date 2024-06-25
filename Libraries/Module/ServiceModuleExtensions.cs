using Microsoft.Extensions.DependencyInjection;
using Module.Interfaces;
using System.Reflection;

namespace Module;

public static class ServiceModuleExtensions
{
    public static IServiceCollection RegisterServiceModules(this IServiceCollection services, Assembly mainAssembly)
    {
        IEnumerable<IServiceModule> modules = ModuleDiscovery<IServiceModule>.DiscoverModules(mainAssembly);
        
        foreach (IServiceModule module in modules)        
            module.RegisterModule(services);
        
        return services;
    }
}
