using System.Text.Json.Serialization;

namespace WaterJugChallenge.Models.RequestsModels
{

    public class WaterJugRequest
    {
        [JsonPropertyName("x_capacity")]
        public int XBucketCapacity { get; set; }

        [JsonPropertyName("y_capacity")]
        public int YBucketCapacity { get; set; }

        [JsonPropertyName("z_amount_wanted")]
        public int ZAmountWanted { get; set; }
    }

}