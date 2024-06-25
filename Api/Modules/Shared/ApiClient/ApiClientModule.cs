using Module.Interfaces;
using Api.Modules.Shared.ApiClient.Services;

namespace Api.Modules.Shared.ApiClient;

internal sealed class ApiClientModule : IServiceModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddHttpClient<ApiClientService>();
        services.AddTransient<ApiClientService>();
        return services;
    }
}
