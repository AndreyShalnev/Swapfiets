using BikeApi.Client.Models;

namespace BikeApi.Client.Client
{
    public interface ITheftBikesClient
    {
        Task<List<Models.Bike>> GetAsync(GetBikesParameters parameters, CancellationToken cancellationToken);
    }
}
