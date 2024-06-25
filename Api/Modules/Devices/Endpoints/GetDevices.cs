using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Api.Modules.Shared.ApiClient.Services;
using Api.Modules.Shared.Core;
using Api.Modules.Devices.Core;

namespace Api.Modules.Devices.Endpoints;

internal static class GetDevices
{
    public static async Task<Ok<ResponseWithPayload<GetDevicesResponse>>> Handler([FromServices] ApiClientService apiClient, [FromBody] RequestWithToken vm) =>
        TypedResults.Ok(value: await apiClient.SetAccessToken(vm.Token).GetAsync<ResponseWithPayload<GetDevicesResponse>>($"devices/v1/{vm.TeamId}"));
}
