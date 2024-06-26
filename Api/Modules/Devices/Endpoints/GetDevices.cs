using Api.Modules.Devices.Core;
using Api.Modules.Shared.ApiClient.Services;
using Api.Modules.Shared.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Modules.Devices.Endpoints;

internal static class GetDevices
{
    public static async Task<Ok<ResponseWithPayload<GetDevicesResponse>>> Handler([FromServices] ApiClientService apiClient, [FromBody] RequestWithToken vm) =>
        TypedResults.Ok(value: await apiClient.SetAccessToken(vm.Token).GetAsync<ResponseWithPayload<GetDevicesResponse>>($"devices/v1/{vm.TeamId}"));
}
