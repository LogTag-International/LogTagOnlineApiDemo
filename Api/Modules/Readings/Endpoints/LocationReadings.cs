using Api.Modules.Readings.Core;
using Api.Modules.Shared.ApiClient.Services;
using Api.Modules.Shared.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Modules.Readings.Endpoints;

internal static class LocationReadings
{
    public static async Task<Ok<ResponseWithPayload<LocationReadingResponse>>> Handler([FromServices] ApiClientService apiClient, [FromBody] RequestWithToken<ReadingsRequest> vm) =>
        TypedResults.Ok(value: await apiClient.SetAccessToken(vm.Token).PostAsync<ResponseWithPayload<LocationReadingResponse>, ReadingsRequest>(vm.Data, $"locationreadings/v1/{vm.TeamId}"));
}
