using System.Text.Json.Serialization;

namespace BikeApi.Client.Web.Models
{
    internal class BikeSearchCount
    {
        [JsonPropertyName("non")]
        public int Non { get; set; }
        [JsonPropertyName("stolen")]
        public int Stolen { get; set; }
        [JsonPropertyName("proximity")]
        public int Proximity { get; set; }
    }
}
