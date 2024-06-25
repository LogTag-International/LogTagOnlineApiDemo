namespace Api.Modules.Shared.Core;

internal sealed record ResponseWithPayload<T>(T[] Data, string Status, DateTime TimestampUtc);
