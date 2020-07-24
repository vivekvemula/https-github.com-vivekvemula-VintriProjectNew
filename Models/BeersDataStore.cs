using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vintri.BeerInfo.API.Punk;

namespace Vintri.BeerInfo.API.Models
{
    public static class BeersDataStore
    {
        /// <summary>
        /// This method gets the beer names from punk url
        /// </summary>
        /// <param name="beerName"></param>
        /// <returns></returns>
        public static List<BeerArray> GetBeerByName(string beerName)
        {
            string jsonstr = "";
            //TODO: Remove hard coding and move this path to appsettings.
            string url = string.Format("https://api.punkapi.com/v2/beers?beer_name={0}", beerName);
            using (WebClient client = new WebClient())
            {
                try
                {
                    jsonstr = client.DownloadString(url);
                    var objData = JsonConvert.DeserializeObject<List<BeerArray>>(jsonstr);
                    return objData;
                }
                catch
                {
                    return null;
                }

            }
        }
    }
}
