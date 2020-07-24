using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Vintri.BeerInfo.API
{
    public class BeerInfoValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                var userName = (string)context.ActionArguments["UserName"];
                var rating = (string)context.ActionArguments["Rating"];
                string error = "";
                if(userName == null && rating == null)
                {
                    error = "User Name and Rating should be entered.\n";
                    error += "Click back button on the browser to re enter the values.\n";
                    context.Result = new BadRequestObjectResult(error);
                }
                else
                {
                    bool isValidUserName = Regex.IsMatch(userName,
                           @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                           @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                           RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

                    if (!isValidUserName)
                    {
                        error = "User Name should be email \n";
                        context.Result = new BadRequestObjectResult(error);
                    }
                    if (Convert.ToInt16(rating) < 1 || Convert.ToInt16(rating) > 5)
                    {
                        error += "Rating should be 1-5";
                        context.Result = new BadRequestObjectResult(error);
                    }

                }
               
            }

            return;

        }
    }
}
