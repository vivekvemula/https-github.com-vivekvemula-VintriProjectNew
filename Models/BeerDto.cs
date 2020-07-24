using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vintri.BeerInfo.API.Models
{
    /// <summary>
    /// This class is used to update the json file
    /// </summary>
    public class BeerDto
    {
        
        public string UserName { get; set; }
        
        public int Rating { get; set; }
        public string Comments { get; set; }
    }
}
