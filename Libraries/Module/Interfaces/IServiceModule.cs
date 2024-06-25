using Microsoft.Extensions.DependencyInjection;

namespace Module.Interfaces;

public interface IServiceModule : IModuleBase
{
    IServiceCollection RegisterModule(IServiceCollection services);
}
