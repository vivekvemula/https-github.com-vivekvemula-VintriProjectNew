using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using Vintri.BeerInfo.API.Models;


namespace Vintri.BeerInfo.API.Punk
{
    public static class Validations
    {
        /// <summary>
        /// This method validates the id with punk beer id
        /// </summary>
        /// <param name="beerId"></param>
        /// <returns>true or false</returns>
        public static bool ValidateBeerId(int beerId)
        {
            string jsonstr = "";
            //Punk Url
            //TODO: Remove hard coding and move this path to appsettings.
            string url = string.Format("https://api.punkapi.com/v2/beers/{0}", beerId);
            using (WebClient client = new WebClient())
            {
                try
                {
                    //Download the string
                    jsonstr = client.DownloadString(url);
                    //Serializes the string to list of beers
                    var objBeers = JsonConvert.DeserializeObject<List<BeerArray>>(jsonstr);
                    int punkBeerId = objBeers[0].id;
                    if (objBeers == null)
                    {
                        return false;
                    }
                    else
                    {
                        if (punkBeerId == beerId)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                }
                catch
                {
                    return false;
                }
            }
           
        }
        /// <summary>
        /// This method validates the beer name with the punk beer name
        /// </summary>
        /// <param name="beerName"></param>
        /// <returns>true or false</returns>
        public static bool ValidateBeerName(string beerName)
        {
            List<BeerArray> listOfBeers = new List<BeerArray>();
            listOfBeers = BeersDataStore.GetBeerByName(beerName);
            try
            {
                if (listOfBeers == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            
        }
    }
}
