namespace SveviaApi.Trafikverket
{

    public class TrafikVerketApiClient : ITrafikVerketApiClient
    {
        private readonly string TRAFIC_INFO = "https://api.trafikinfo.trafikverket.se/v2/data.json";
        private readonly string AUTH_KEY = "54c80703a7e24c4a898b17ccd6ef4a39";
        private HttpClient _httpClient;
        private readonly ILogger<TrafikVerketApiClient> _logger;

        public TrafikVerketApiClient(ILogger<TrafikVerketApiClient> logger, HttpClient httpClient)
        {
            this._logger = logger;
            this._httpClient = httpClient;
            httpClient.BaseAddress = new Uri(this.TRAFIC_INFO);
        }



        private string GetTrafficFlowRequestBody()
        {
            var request = "<REQUEST>" +
                           $"<LOGIN authenticationkey='{this.AUTH_KEY}' />" +
                            "<QUERY objecttype='TrafficFlow' schemaversion='1.4' orderby='ModifiedTime' sseurl='true' limit='100'>" +
                               "<INCLUDE>AverageVehicleSpeed</INCLUDE>" +
                               "<INCLUDE>VehicleType</INCLUDE>" +
                               "<INCLUDE>VehicleFlowRate</INCLUDE>" +
                               "<INCLUDE>MeasurementTime</INCLUDE>" +
                               "<INCLUDE>ModifiedTime</INCLUDE>" +
                           "</QUERY>" +
                       "</REQUEST>";
            return request;
        }



        public async Task<TrafficFlow[]> GetTrafficInfo()
        {
            var body = this.GetTrafficFlowRequestBody();
            var requestMessage = new StringContent(body);

            this._logger.LogInformation("Fetching trafficflow information");
            var response = await this._httpClient.PostAsync("", requestMessage);
            response.EnsureSuccessStatusCode();

            var serializedData = await response.Content.ReadFromJsonAsync<Rootobject>();

            if (serializedData != null && serializedData.Response.Result.Length > 0)
            {
                return serializedData.Response.Result[0].TrafficFlow;
            }
            return Array.Empty<TrafficFlow>();
        }
    }

}