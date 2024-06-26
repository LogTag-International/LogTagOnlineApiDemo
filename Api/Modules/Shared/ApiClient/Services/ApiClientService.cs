using System.Text.Json;
using Api.Extensions;

namespace Api.Modules.Shared.ApiClient.Services;

internal sealed class ApiClientService : IDisposable
{
    private readonly HttpClient _httpClient;

    private readonly string _apiPath;

    private static JsonSerializerOptions DefaultSerializationOptions { get => new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }; }

    public ApiClientService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(configuration.GetStringValueOrThrowUnreachable("LtoApi:Server"));
        _apiPath = configuration.GetStringValueOrThrowUnreachable("LtoApi:Path");
    }

    public async Task<TResponse> PostAsync<TResponse, TRequest>(TRequest body, string endpoint) =>
        await (await _httpClient.PostAsJsonAsync($"{_apiPath}/{endpoint}", body, DefaultSerializationOptions)).Content.ReadFromJsonAsync<TResponse>() ?? throw new NullReferenceException();

    public async Task<TResponse> GetAsync<TResponse>(string endpoint) =>
        await _httpClient.GetFromJsonAsync<TResponse>($"{_apiPath}/{endpoint}", DefaultSerializationOptions) ?? throw new NullReferenceException();

    public void Dispose() => _httpClient?.Dispose();

    public ApiClientService SetAccessToken(string token)
    {
        _httpClient.DefaultRequestHeaders.Add("Access_token", token);
        // Return this instance to allow for chaining.
        return this;
    }
}
