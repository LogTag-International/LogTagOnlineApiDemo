using System.Diagnostics;

namespace Api.Extensions;

internal static class IConfigurationExtensions
{
    public static string GetStringValueOrThrowUnreachable(this IConfiguration configurationManager, string node) =>
        configurationManager[node] ?? throw new UnreachableException();
}
