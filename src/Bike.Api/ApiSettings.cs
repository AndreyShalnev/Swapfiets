namespace Bike.Api
{
    public class ApiSettings
    {
        public BikeApiSettings BikeApiSettings { get; set; }
        public string ApplicationName { get; set; }
    }

    public class BikeApiSettings
    {
        public string BaseUri { get; set; }
        public string ThreftBikesRelativeUri { get; set; }
        public string ThreftBikesCountRelativeUri { get; set; }

    }
}
