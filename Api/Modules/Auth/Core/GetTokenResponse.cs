namespace Api.Modules.Auth.Core;

internal sealed record GetTokenResponse(string Token, List<Team> Teams);

internal sealed record Team(int Id, string Name, string UserAccountType);
