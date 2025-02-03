using System.Collections.Immutable;

namespace Api.Modules.Shipments.Core;

internal sealed record ShipmentsResponse(
    int ShipmentId,
    string ShipmentName,
    string ShipmentState,
    ImmutableList<ShipmentDevices> Devices
);
