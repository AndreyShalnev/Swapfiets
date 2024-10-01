using BikeApi.Client.Mapper;
using BikeApi.Client.Models;
using Flurl;
using Serilog;

namespace BikeApi.Client.Client
{
    internal class ThreftBikesCountClient : ClientBase<Web.Models.BikeSearchCount>, IThreftBikesCountClient
    {
        private readonly string _relativeUri;

        public ThreftBikesCountClient(HttpClient httpClient, string relativeUri, ILogger logger)
            : base(httpClient, logger) 
        { 
            _relativeUri = relativeUri;
        }

        public async Task<Models.BikeSearchCount> GetAsync(GetBikesCountParameters parameters, CancellationToken cancellationToken)
        {
            _logger.Information("Fetching bike thefts for city: {City}, distance: {Distance}, stolenness: {Stolenness}", parameters.City, parameters.Distance, parameters.Stolenness);

            var request = GetRequest(parameters);
            var response = await ExecuteAsync(request, cancellationToken);

            return BikeSearchCountMapper.ToModel(response);
        }

        private HttpRequestMessage GetRequest(GetBikesCountParameters parameters)
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
