using BikeApi.Client.Client;
using HttpClientFactoryLite;
using Serilog;


namespace BikeApi.Client
{
    public sealed class BikeApiClientFactory
    {
        private readonly string _httpClientName;
        private readonly HttpClientFactory _httpClientFactory;
        private readonly BikeApiSettings _settings;
        private readonly ILogger _logger;

        public BikeApiClientFactory(string applicationName, BikeApiSettings settings, ILogger logger)
        {
            if (string.IsNullOrWhiteSpace(applicationName))
            {
                throw new ArgumentNullException(nameof(applicationName));
            }

            ValidateSettings(settings);

            _httpClientName = $"{applicationName}-http-client";
            _httpClientFactory = new HttpClientFactory();

            _httpClientFactory.Register(_httpClientName,
                builder =>
                {
                    builder.ConfigureHttpClient(baseHttpClient =>
                    {
                        baseHttpClient.BaseAddress = new Uri(settings.BaseUri);
                    });
                });

            _settings = settings;
            _logger = logger;
        }

        internal HttpClient CreateHttpClient()
        {
            return _httpClientFactory.CreateClient(_httpClientName);
        }

        public ITheftBikesClient CreateBikeClient()
        {
            var client = CreateHttpClient();
            return new TheftBikesClient(client, _settings.ThreftBikesRelativeUri, _logger);
        }

        public IThreftBikesCountClient CreateThreftBikesCountClient()
        {
            var client = CreateHttpClient();
            return new ThreftBikesCountClient(client, _settings.ThreftBikesCountRelativeUri, _logger);
        }

        private void ValidateSettings(BikeApiSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (string.IsNullOrWhiteSpace(settings.BaseUri))
            {
                throw new ArgumentException(nameof(settings.BaseUri));
            }

            if (string.IsNullOrWhiteSpace(settings.ThreftBikesRelativeUri))
            {
                throw new ArgumentException(nameof(settings.ThreftBikesRelativeUri));
            }

            if (string.IsNullOrWhiteSpace(settings.ThreftBikesCountRelativeUri))
            {
                throw new ArgumentException(nameof(settings.ThreftBikesCountRelativeUri));
            }
        }
    }
}
