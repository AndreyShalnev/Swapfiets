using System.Text.Json.Serialization;

namespace BikeApi.Client.Web.Models
{
    internal class BikeDataResponse
    {
        [JsonPropertyName("bikes")]
        public List<Bike> Bikes { get; set; }
    }

    internal class Bike
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("date_stolen")]
        public int DateStolen { get; set; }

        [JsonPropertyName("stolen_location")]
        public string StolenLocation { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
