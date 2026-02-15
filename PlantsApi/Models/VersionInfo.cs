namespace PlantsApi.Models;

public class VersionInfo
{
    public string Version { get; set; } = "1.0.0";
    public string GitCommit { get; set; } = "unknown";
    public string BuildDate { get; set; } = DateTime.UtcNow.ToString("o");
    public string Environment { get; set; } = "development";
}