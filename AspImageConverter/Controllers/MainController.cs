using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspImageConverter.Conversion;
using AspImageConverter.Webfetch;
using AspImageConverter.Models;
using System;
using System.IO;

namespace AspImageConverter.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        [Route("/convert")]
        [HttpGet]
        public async Task<IActionResult> Get(string file, string output) {
            MemoryStream webResponse = await WebfetchImage.ByGetUrl(file);
            
            //Return a new file using the URI and Type provided by the user
            return File(webResponse.ToArray(), $"image/{output}");
        }
        [Route("/convert")]
        [HttpPost]
        public async Task<IActionResult> Get([FromBody] ImageRequest req)
        {
            //Operation if the requested file is not a UrlFile (go to Base64 validation)
            var fileStream = await ImageConverter.GetStream(req.file, req.output);

            //Return a new file using the Base64 and Type provided by the user
            return File(fileStream.ToArray(), $"image/{req.output}");
        }

        [Route("/test")]
        [HttpGet]
        public ContentResult Get() {
            /*
                Note: Manually insert "ManualTests/ConversionTest.js" in console
            */
            return Content("");
        }
    }
}
