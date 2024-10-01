using BikeApi.Client.Models;

namespace BikeApi.Client.Client
{
    public interface IThreftBikesCountClient
    {
        Task<Models.BikeSearchCount> GetAsync(GetBikesCountParameters parameters, CancellationToken cancellationToken);
    }
}
