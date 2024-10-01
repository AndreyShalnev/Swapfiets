namespace BikeApi.Client.Mapper
{
    internal static class BikeMapper
    {
        public static List<Models.Bike> ToModel(List<Web.Models.Bike> bikes)
        {
            return bikes.Select(ToModel).ToList();
        }

        public static Models.Bike ToModel(Web.Models.Bike bike)
        {
            return new Models.Bike()
            {
                DateStolen = bike.DateStolen,
                Description = bike.Description,
                Location = bike.StolenLocation,
                Title = bike.Title,
            };
        }
    }
}
