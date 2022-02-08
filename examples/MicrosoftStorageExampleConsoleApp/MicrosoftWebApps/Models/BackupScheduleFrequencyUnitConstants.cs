namespace MicrosoftExampleConsoleApp.MicrosoftWebApps.Models
{
    /// <summary>
    /// The unit of time for how often the backup should be executed (e.g. for weekly backup, this should be set to Day and FrequencyInterval should be set to 7)
    /// </summary>
    public static class BackupScheduleFrequencyUnitConstants
    {
        public const string Day = "Day";

        public const string Hour = "Hour";
    }
}
