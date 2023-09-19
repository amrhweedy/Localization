using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Localizationandglobalization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly IStringLocalizer<LanguagesController> localizer;  // i use it to read the values from the files in the resources folder

        public LanguagesController(IStringLocalizer<LanguagesController> localizer)
        {
            this.localizer = localizer;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = $" {localizer["Welcome"].Value} , {localizer["Name"].Value}";  

            return Ok(result);   // "Welocme" is the key in the file in the Resources folder
                                               // when i run the app without creating the resources folder the result is 
        }
    }
}
