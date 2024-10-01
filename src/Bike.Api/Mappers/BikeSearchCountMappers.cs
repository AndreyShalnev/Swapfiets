namespace Bike.Api.Mappers
{
    public static class BikeSearchCountMappers
    {
        public static Models.BikeSearchCount MapToWebModel(Domain.Models.BikeSearchCount bikeSearchCount)
        {
            return new Models.BikeSearchCount
            {
                Non = bikeSearchCount.Non,
                Proximity = bikeSearchCount.Proximity,
                Stolen = bikeSearchCount.Stolen
            };
        }
    }
}
