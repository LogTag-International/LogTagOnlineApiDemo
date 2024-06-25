using Module.Interfaces;
using System.Reflection;

namespace Module;

internal static class ModuleDiscovery<TModuleInterface> where TModuleInterface : IModuleBase
{
    public static IEnumerable<TModuleInterface> DiscoverModules(Assembly mainAssembly)
        => mainAssembly
            .GetTypes()
                .Where(type => type.IsClass && type.IsAssignableTo(typeof(TModuleInterface)))
                .Select(Activator.CreateInstance)
                .Cast<TModuleInterface>();
}
