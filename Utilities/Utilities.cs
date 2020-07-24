using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Vintri.BeerInfo.API.Models;



namespace Vintri.BeerInfo.API.Utilities
{
    public static class JsonFiles
    {
        static string jsonFile = @"C:\Temp\database.json";
        /// <summary>
        /// This method creates database.json
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="ratings"></param>
        /// <param name="comments"></param>
        /// <returns>success or failure</returns>
        public static bool CreateJsonFile(string userName, string ratings, string comments)
        {
            try
            {
                BeerDto beerDto = new BeerDto();
                beerDto.UserName = userName;
                //beerDto.Id = Convert.ToInt32(Request.Form["Id"]);
                beerDto.Rating = Convert.ToInt32(ratings);
                beerDto.Comments = comments;
                
                List<BeerDto> listBeerDtos = new List<BeerDto>();
                listBeerDtos.Add(beerDto);
                //string json = JsonConvert.SerializeObject(beerDto);
                string json = JsonConvert.SerializeObject(listBeerDtos);
                //TODO: Remove hard coding and move this path to appsettings.
                
                System.IO.File.AppendAllTextAsync(jsonFile, json);
                string jsonTxt = File.ReadAllText(jsonFile);
                //The generated json was not a valid json structure. So replaced.
                System.IO.File.WriteAllText(jsonFile, jsonTxt.Replace("][", ","));
                return true;
            }
            catch
            {
                return false;
            }
           
        }
        public static List<BeerDto> GetRatingsFromJson()
        {
            
            List<BeerDto> listOfRatings = new List<BeerDto>();
           
            using (StreamReader file = System.IO.File.OpenText(jsonFile))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                try
                {
                    JArray o2 = (JArray)JToken.ReadFrom(reader);
                    //JObject o2 = (JObject)JToken.ReadFrom(reader);
                    //var obj = o2.ToObject<List<BeerDto>>();
                    listOfRatings = o2.ToObject<List<BeerDto>>();
                }
                catch(Exception ex)
                {
                    listOfRatings = null;
                }
               
            }
            return listOfRatings;


            /*
            if (File.Exists(@"c:\temp\database.json"))
            {
                
                String JSONtxt = File.ReadAllText(@"c:\temp\database.json");

                //Capture JSON string for each object, including curly brackets 
                Regex regex = new Regex(@".*(?<=\{)[^}]*(?=\}).*", RegexOptions.IgnoreCase);
                MatchCollection matches = regex.Matches(JSONtxt);
                               
                foreach (Match match in matches)
                {
                    string objStr = match.ToString();
                    BeerDto account = Newtonsoft.Json.JsonConvert.DeserializeObject<BeerDto>(objStr);
                    listOfAccounts.Add(account);
                }
            }
            
            return listOfAccounts;
            */
        }
    }
}
