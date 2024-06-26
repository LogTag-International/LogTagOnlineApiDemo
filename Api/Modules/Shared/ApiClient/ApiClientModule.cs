using Api.Modules.Shared.ApiClient.Services;
using Module.Interfaces;

namespace Api.Modules.Shared.ApiClient;

internal sealed class ApiClientModule : IServiceModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        // Courtesy of: https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory#typed-clients
        services.AddHttpClient<ApiClientService>();
        // Using typed clients in singleton services can be dangerous. https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory#avoid-typed-clients-in-singleton-services
        services.AddTransient<ApiClientService>();
        return services;
    }
}
