using AMS.Mobile.Constants;
using AMS.Mobile.Interfaces;
using AMS.Mobile.Models;
using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMS.Mobile.Services
{
    public class TractorInfoService : ITractorInfoService
    {
        private string endpoint;

        public TractorInfoService()
        {
            endpoint = GlobalSettings.TractorInfoApiEndpoint;
        }

        public Task<IEnumerable<TractorInfo>> GetTractorsAsync()
        {
            return endpoint.GetJsonAsync<IEnumerable<TractorInfo>>();
        }
    }
}
