using System.Text.Json;
using Api.Extensions;

namespace Api.Modules.Shared.ApiClient.Services;

internal sealed class ApiClientService : IDisposable
{
    private readonly HttpClient _HttpClient;

    private readonly string _ApiPath;

    public ApiClientService(HttpClient httpClient, IConfiguration configuration)
    {
        _HttpClient = httpClient;
        _HttpClient.BaseAddress = new Uri(configuration.GetStringValueOrThrowUnreachable("LtoApi:Server"));
        _ApiPath = configuration.GetStringValueOrThrowUnreachable("LtoApi:Path");
    }

    public async Task<TResponse> PostAsync<TResponse, TRequest>(TRequest body, string endpoint) =>
        await (await _HttpClient.PostAsJsonAsync($"{_ApiPath}/{endpoint}", body, _DefaultSerializationOptions)).Content.ReadFromJsonAsync<TResponse>() ?? throw new NullReferenceException();

    public async Task<TResponse> GetAsync<TResponse>(string endpoint) =>
        await _HttpClient.GetFromJsonAsync<TResponse>($"{_ApiPath}/{endpoint}", _DefaultSerializationOptions) ?? throw new NullReferenceException();

    public void Dispose() => _HttpClient?.Dispose();

    public ApiClientService SetAccessToken(string token)
    {
        _HttpClient.DefaultRequestHeaders.Add("Access_token", token);
        // Return this instance to allow for chaining.
        return this;
    }

    private static JsonSerializerOptions _DefaultSerializationOptions { get => new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }; }
}
