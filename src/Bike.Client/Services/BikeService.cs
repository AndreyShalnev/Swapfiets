using BikeApi.Client.Client;
using BikeApi.Client.Models;

namespace BikeApi.Client.Services
{
    public class BikeService
    {
        private readonly ITheftBikesClient _client;
        public BikeService(ITheftBikesClient bikeClient) 
        {
            _client = bikeClient;
        }
        /*
        public async Task<List<Models.Bike>> GetTheftsAsync(GetTheftBikesParameters parameters, CancellationToken cancellationToken)
        {

        }*/
    }
}
