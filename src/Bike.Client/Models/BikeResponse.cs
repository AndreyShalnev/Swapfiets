namespace BikeApi.Client.Models
{
    public class BikeResponse
    {
        public string City { get; set; }
        public string Stolenness { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public List<Bike> Bikes { get; set; }
    }
}
