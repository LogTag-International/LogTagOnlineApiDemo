using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Api.Modules.Shared.ApiClient.Services;
using Api.Modules.Auth.Core;

namespace Api.Modules.Auth.Endpoints;

internal static class GetToken
{
    public static async Task<Ok<GetTokenResponse>> Handler([FromServices] ApiClientService apiClient, [FromBody] GetTokenRequest vm) =>
        TypedResults.Ok(value: await apiClient.PostAsync<GetTokenResponse, GetTokenRequest>(vm, "token/v1/public"));
}
