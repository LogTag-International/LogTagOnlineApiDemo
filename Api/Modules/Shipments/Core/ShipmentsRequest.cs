namespace Api.Modules.Shipments.Core;

internal sealed record ShipmentsRequest(
    ShipmentFilterTypeEnum shipmentStateFilterId
);
