namespace Api.Modules.Shipments.Core;

internal sealed record ShipmentDevices(
    string SerialNumber,
    string DeviceStatus,
    int? LoggerProfileId
);
