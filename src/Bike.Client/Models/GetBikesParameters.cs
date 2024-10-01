namespace BikeApi.Client.Models
{
    public record GetBikesParameters (string City, int Distance, string Stolenness, int Page, int PerPage)
    {

    }
}
