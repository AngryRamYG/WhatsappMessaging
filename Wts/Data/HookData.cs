using System.Text.Json.Serialization;

namespace Wts.Data
{
    public class HookData
    {
        [JsonPropertyName("event_type")]
        public string EventType { get; set; } = null!;

        [JsonPropertyName("instanceId")]
        public string InstanceId { get; set; } = null!;

        [JsonPropertyName("data")]
        public login? Data { get; set; }
    }
}
