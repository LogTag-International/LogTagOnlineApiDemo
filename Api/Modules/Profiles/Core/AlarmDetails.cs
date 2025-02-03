namespace Api.Modules.Profiles.Core;

internal sealed record AlarmDetails(
    bool IsUpper,
    double? ThresholdValue,
    int NumberOfReadingsBeforeAlert,
    string AlarmTriggerType,
    string Sensor
);
