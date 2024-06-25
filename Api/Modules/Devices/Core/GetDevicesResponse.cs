namespace Api.Modules.Devices.Core;

internal sealed record GetDevicesResponse(string SerialNumber, DateTime RegistrationDateUtc, DateTime? LastConnectionDateUtc, string Model, string? Description, string DeviceState);
