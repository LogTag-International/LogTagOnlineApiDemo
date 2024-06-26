namespace Api.Modules.Readings.Core;

internal sealed record LTGeoReadingResponse(DateTime DateUtc, double Temperature, double Humidity, double Lux, double Shock, double Latitude, double Longitude) : IDeviceReadingResponse;
