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
        /// <summary>
        /// Average vehicle speed
        /// </summary>
        public float AverageVehicleSpeed { get; set; }
        /// <summary>
        /// Average vehicle flow rate
        /// </summary>
        public int VehicleFlowRate { get; set; }
        /// <summary>
        /// Type of vehicle
        /// </summary>
        public string? VehicleType { get; set; }
        /// <summary>
        /// Time stamp when data is registred
        /// </summary>
        public DateTime MeasurementTime { get; set; }
        /// <summary>
        /// If row is modified, when.
        /// </summary>
        public DateTime ModifiedTime { get; set; }
    }


}
