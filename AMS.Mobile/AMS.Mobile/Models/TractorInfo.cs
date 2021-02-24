using System.Collections.Generic;

namespace AMS.Mobile.Models
{
    public class TractorInfo
    {
        public int TractorNumber { get; set; }
        public bool IsAtGarage { get; set; }
        public IEnumerable<FuelLevelInfo> FuelInfo { get; set; }
    }
}
