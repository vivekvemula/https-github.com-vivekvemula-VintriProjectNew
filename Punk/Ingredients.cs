using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vintri.BeerInfo.API.Punk
{
    public class Ingredients
    {
        public List<Malt> malt { get; set; }
        public List<Hop> hops { get; set; }
        public string yeast { get; set; }

    }
}
