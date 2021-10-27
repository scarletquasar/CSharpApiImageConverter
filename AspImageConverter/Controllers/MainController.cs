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
        [HttpPost]
        public async Task<FileContentResult> Get([FromBody] ImageRequest req)
        {
            //Operation if the requested file is a UrlFile

            if (Uri.IsWellFormedUriString(req.uri, UriKind.Absolute)) {
                MemoryStream webResponse = await WebfetchImage.ByGetUrl(req.uri);
                
                //Return a new file using the URI and Type provided by the user
                return File(webResponse.ToArray(), $"image/{req.output}");
            }
            //Operation if the requested file is not a UrlFile (go to Base64 validation)
            
            else {
                var fileStream = await ImageConverter.GetStream(req.uri, req.output);

                //Return a new file using the Base64 and Type provided by the user
                return File(fileStream.ToArray(), $"image/{req.output}");
            }

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
