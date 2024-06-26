namespace Api.Modules.Readings.Core;

internal sealed record LocationReadingResponse(DateTime DateUtc, double Temperature) : IDeviceReadingResponse;
