using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using AspImageConverter.Conversion;

namespace AspImageConverter.Controllers
{
    [ApiController]
    [Route("/")]
    public class MainController : ControllerBase
    {

        [HttpGet]
        public async Task<FileContentResult> Get(string file = "R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==", string output = "jpg")
        {
            var fileStream = await ConversionCore.GetStream(file, output);
            return File(fileStream.ToArray(), $"image/{output}");
        }
    }
}
