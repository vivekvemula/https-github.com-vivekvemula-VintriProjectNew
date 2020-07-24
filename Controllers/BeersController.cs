using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using Vintri.BeerInfo.API.Models;
using Vintri.BeerInfo.API.Punk;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Vintri.BeerInfo.API.Utilities;


namespace Vintri.BeerInfo.API.Controllers
{
    [ApiController]
    [Route("api/beers")]
    public class BeersController : Controller
    {
        [HttpGet]
        public IActionResult GetBeers(string beerName)
        {
            bool isValidBeerName = Validations.ValidateBeerName(beerName);
            
            List<BeerArray> listOfBeers = new List<BeerArray>();
            List<BeerDto> listOfRatings = new List<BeerDto>();
            if (isValidBeerName)
            {
                listOfBeers = BeersDataStore.GetBeerByName(beerName);
                if(listOfBeers != null)
                {
                    listOfRatings = Utilities.JsonFiles.GetRatingsFromJson();
                }
                else
                {
                    //TODO Error
                }
            }
            else
            {
                return BadRequest(string.Format("Invalid Beer Name/ Id {0}", beerName));
            }        
               return Ok(Output.GenerateOutput(listOfBeers, listOfRatings));
        }
        /// <summary>
        /// This method is invoked when the url contains Id : http://localhost:1028/api/beers/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Either view or error page</returns>
        [HttpGet("{id}")]
        public IActionResult GetBeer(int id)
        {
            //Check if the beer id exists on Punk
            bool IsValidBeerId = Validations.ValidateBeerId(id);
            //If valid beer id show view where the user enters name, rating and comments
            if(IsValidBeerId)
            {
                //View enables the user to enter name, rating and comments
                return View("AddRating");
            }
            else
            {
                //If it is nt a valid beer id return error
                return BadRequest(string.Format("Invalid BeerId {0}", id));
            }
        }
        /// <summary>
        /// This method is invoked when the user clicks create button on the view.
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Rating"></param>
        /// <returns>Success or Error message</returns>
        [HttpPost("Add")]
        [BeerInfoValidation]
        public IActionResult Add([FromForm] string UserName, [FromForm] string Rating) 
        {
            //Returns true after the C:\Temp\database.json is appended. IF the file doesn't exist it creates.
            bool jsonCreated = JsonFiles.CreateJsonFile(UserName, Rating, Request.Form["Comments"]);
            if(jsonCreated)
            {
                //Show success message
                return Ok(string.Format("database.json is appended with username {0}, rating {1}",UserName,Rating));
            }
            else
            {
                //Show error message
                return BadRequest("JSon File not created");
            }
            
        }
    }
}
