using Newtonsoft.Json;

namespace SveviaApi.Trafikverket
{


    public class Rootobject
    {
        [JsonProperty(PropertyName = "RESPONSE")]
        public Response Response { get; set; } = new Response();
    }

    public class Response
    {
        [JsonProperty(PropertyName = "RESULT")]
        public Result[] Result { get; set; } = new Result[0];
    }

    public class Result
    {
        public TrafficFlow[] TrafficFlow { get; set; } = new TrafficFlow[0];
    }


    public class TrafficFlow
    {
        public float AverageVehicleSpeed { get; set; }
        public int VehicleFlowRate { get; set; }
        public string? VehicleType { get; set; }
        public DateTime MeasurementTime { get; set; }
        public DateTime ModifiedTime { get; set; }
    }


}
