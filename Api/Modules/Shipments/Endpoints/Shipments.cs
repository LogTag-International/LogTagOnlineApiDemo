using Api.Modules.Shipments.Core;
using Api.Modules.Shared.ApiClient.Services;
using Api.Modules.Shared.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Modules.Shipments.Endpoints;

internal static class Shipments
{
    public static async Task<Ok<ResponseWithPayload<ShipmentsResponse>>> Handler([FromServices] ApiClientService apiClient, [FromBody] RequestWithToken<ShipmentsRequest> vm) =>
        TypedResults.Ok(value: await apiClient.SetAccessToken(vm.Token).PostAsync<ResponseWithPayload<ShipmentsResponse>, ShipmentsRequest>(vm.Data, $"shipments/v1/{vm.TeamId}"));
}
