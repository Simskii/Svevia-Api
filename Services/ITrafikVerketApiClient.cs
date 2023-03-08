using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SveviaApi.Trafikverket
{
    public interface ITrafikVerketApiClient
    {
        public Task<TrafficFlow[]> GetTrafficInfo();
    }
}