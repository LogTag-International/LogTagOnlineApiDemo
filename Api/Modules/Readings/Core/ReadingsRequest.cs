namespace Api.Modules.Readings.Core;

internal sealed record ReadingsRequest(string SerialNumber, DateTime StartDateUtc, DateTime EndDateUtc);
