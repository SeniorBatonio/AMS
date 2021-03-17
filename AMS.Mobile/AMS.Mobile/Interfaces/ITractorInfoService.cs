using AMS.Mobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMS.Mobile.Interfaces
{
    public interface ITractorInfoService
    {
        Task<IEnumerable<TractorInfo>> GetTractorsAsync();
    }
}
