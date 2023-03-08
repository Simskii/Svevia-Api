using Microsoft.AspNetCore.Mvc;
using SveviaApi.Trafikverket;
namespace SveviaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TrafficFlowController : ControllerBase
{

    ITrafikVerketApiClient _sveviaClient;
    public TrafficFlowController(ITrafikVerketApiClient sveviaClient)
    {
        this._sveviaClient = sveviaClient;
    }


    /// <summary>
    /// Returns traffic flow data
    /// </summary>
    /// <returns>An array of recent traffic flow data</returns>
    [HttpGet]
    public async Task<TrafficFlow[]> GetTrafficFlow()
    {
        return await this._sveviaClient.GetTrafficInfo();
    }
}
