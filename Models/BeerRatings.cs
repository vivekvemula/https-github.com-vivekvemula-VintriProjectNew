using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vintri.BeerInfo.API.Models
{
    /// <summary>
    /// Combine both data sets
    /// </summary>
    public class BeerRatings
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<BeerDto> userRatings;
    }
}
