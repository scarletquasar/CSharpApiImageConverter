using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspImageConverter.Conversion;
using AspImageConverter.Models;

namespace AspImageConverter.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        [Route("/convert")]
        [HttpPost]
        public async Task<FileContentResult> Get([FromBody] ImageRequest req)
        {
            var fileStream = await ConversionCore.GetStream(req.base64, req.output);

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
