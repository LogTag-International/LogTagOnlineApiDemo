namespace Api.Modules.Profiles.Core;

internal sealed record GetProfilesResponse(
    int Id,
    string Name,
    string Model,
    int RecordingIntervalInSeconds,
    int StartDelayInSeconds,
    bool? AlarmIndicatorEnabled,
    bool? AllowLoggingStop,
    List<AlarmDetails> Alarms
);
