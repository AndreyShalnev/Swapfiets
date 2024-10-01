namespace BikeApi.Client.Mapper
{
    internal static class BikeSearchCountMapper
    {
        public static Models.BikeSearchCount ToModel(Web.Models.BikeSearchCount model)
        {
            return new Models.BikeSearchCount
            {
                Non = model.Non,
                Proximity = model.Proximity,
                Stolen = model.Stolen
            };
        }
    }
}
