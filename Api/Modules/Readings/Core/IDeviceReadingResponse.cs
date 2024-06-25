namespace Api.Modules.Readings.Core;

internal interface IDeviceReadingResponse
{
    public DateTime DateUtc { get; init; }
    public double Temperature { get; init; }
}
