using BikeApi.Client.Mapper;
using BikeApi.Client.Models;
using BikeApi.Client.Web.Models;
using Flurl;
using Serilog;

namespace BikeApi.Client.Client
{
    internal class TheftBikesClient : ClientBase<BikeDataResponse>, ITheftBikesClient
    {
        private readonly string _relativeUri;

        public TheftBikesClient(HttpClient httpClient, string relativeUri, ILogger logger)
            : base(httpClient, logger) 
        { 
            _relativeUri = relativeUri;
        }

        public async Task<List<Models.Bike>> GetAsync(GetBikesParameters parameters, CancellationToken cancellationToken)
        {
            _logger.Information("Fetching bike thefts for city: {City}, distance: {Distance}, stolenness: {Stolenness}", parameters.City, parameters.Distance, parameters.Stolenness);

            var request = GetRequest(parameters);
            var response = await ExecuteAsync(request, cancellationToken);

            return BikeMapper.ToModel(response.Bikes);
        }

        private HttpRequestMessage GetRequest(GetBikesParameters parameters)
        {
            var url = _relativeUri
                        .SetQueryParam("location", parameters.City)
                        .SetQueryParam("distance", parameters.Distance)
                        .SetQueryParam("stolenness", parameters.Stolenness);

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url, UriKind.Relative),
                Method = HttpMethod.Get
            };
            return request;
        }
    }
}
