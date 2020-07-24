using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vintri.BeerInfo.API.Models;
using Vintri.BeerInfo.API.Punk;

namespace Vintri.BeerInfo.API.Utilities
{
    public class Output
    {
        public static string GenerateOutput(List<BeerArray> listOfBeers, List<BeerDto> listOfRatings)
        {
            string jsonRatings = null;
            BeerRatings beerRatings = new BeerRatings();
            List<BeerRatings> listOfBeerRatings = new List<BeerRatings>();
            try
            {
                foreach(BeerArray eachBeer in listOfBeers)
                {
                    beerRatings.Id = listOfBeers[0].id;
                    beerRatings.name = listOfBeers[0].name;
                    beerRatings.description = listOfBeers[0].description;
                    beerRatings.userRatings = listOfRatings;
                    listOfBeerRatings.Add(beerRatings);
                }
                
                jsonRatings = JsonConvert.SerializeObject(listOfBeerRatings);
            }
            catch
            {
                //TODO Error
            }
            return jsonRatings;
        }
    }
}
