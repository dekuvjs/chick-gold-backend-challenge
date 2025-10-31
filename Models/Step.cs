using System.Text.Json.Serialization;


public class Step
{
    [JsonPropertyName("step")]
    public int StepNumber { get; set; }

    [JsonPropertyName("bucketX")]
    public int BucketX { get; set; }

    [JsonPropertyName("bucketY")]
    public int BucketY { get; set; }

    [JsonPropertyName("action")]
    public string Action { get; set; } = string.Empty;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}