using Bike.Domain.Models;

namespace Bike.Domain.Ports
{
    public interface IBikeService
    {
        Task<BikeSearchCount> GetTheftCountAsync(string city, int distance, string stolenness, CancellationToken cancellationToken);
    }
}
