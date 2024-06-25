namespace Api.Modules.Shared.Core;

internal sealed record RequestWithToken(string Token, int TeamId);

internal sealed record RequestWithToken<T>(string Token, int TeamId, T Data);
