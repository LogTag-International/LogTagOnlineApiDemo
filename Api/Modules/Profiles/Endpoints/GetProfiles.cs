using Api.Modules.Profiles.Core;
using Api.Modules.Shared.ApiClient.Services;
using Api.Modules.Shared.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Modules.Profiles.Endpoints;

internal static class GetProfiles
{
    public static async Task<Ok<ResponseWithPayload<GetProfilesResponse>>> Handler([FromServices] ApiClientService apiClient, [FromBody] RequestWithToken vm) =>
        TypedResults.Ok(value: await apiClient.SetAccessToken(vm.Token).GetAsync<ResponseWithPayload<GetProfilesResponse>>($"profiles/v1/{vm.TeamId}"));
}
