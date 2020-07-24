using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vintri.BeerInfo.API.Punk
{
    public class Method
    {
        public List<MashTemp> mash_temp { get; set; }
        public Fermentation fermentation { get; set; }
        public string twist { get; set; }

    }
}
