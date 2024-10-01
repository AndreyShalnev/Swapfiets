using BikeApi.Client.Client;
using Bike.Domain.Ports;
using BikeApi.Client.Models;
using BikeSearchCount = Bike.Domain.Models.BikeSearchCount;

namespace Bike.Domain.Adapters
{
    public class BikeService : IBikeService
    {
        private readonly IThreftBikesCountClient _threftBikesCountClient;

        public BikeService(IThreftBikesCountClient threftBikesCountClient)
        {
            _threftBikesCountClient = threftBikesCountClient;
        }

        public async Task<BikeSearchCount> GetTheftCountAsync(string city, int distance, string stolenness, CancellationToken cancellationToken)
        {
            var parameters = new GetBikesCountParameters(City: city, Distance: distance, Stolenness: stolenness);
            var searchCount = await _threftBikesCountClient.GetAsync(parameters, cancellationToken);

            return new BikeSearchCount
            {
                Non = searchCount.Non,
                Stolen = searchCount.Stolen,
                Proximity = searchCount.Proximity
            };
        }
    }
}
