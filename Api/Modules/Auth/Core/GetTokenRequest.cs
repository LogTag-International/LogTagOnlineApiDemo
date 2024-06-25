namespace Api.Modules.Auth.Core;

internal sealed record GetTokenRequest(string Email, string Password);
