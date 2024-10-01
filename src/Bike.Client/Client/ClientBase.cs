using Serilog;
using System.Text.Json;

namespace BikeApi.Client.Client
{
    public class ClientBase<TResponse>
        where TResponse : new()
    {
        protected readonly HttpClient _httpClient;
        protected readonly ILogger _logger;

        public ClientBase(HttpClient httpClient, ILogger logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        protected async Task<TResponse> ExecuteAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _httpClient.SendAsync(request, cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Error("Error fetching data from Bike Index API. Status Code: {StatusCode}", response.StatusCode);
                    throw new HttpRequestException($"Error fetching data from Bike Index API. Status Code: {response.StatusCode}");
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                var bikeDataResponse = JsonSerializer.Deserialize<TResponse>(responseContent);

                return bikeDataResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while sending the request: {Request}", request);
                throw;
            }
        }
    }
}
