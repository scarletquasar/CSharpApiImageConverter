using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace AspImageConverter.Controllers
{
    [ApiController]
    [Route("/")]
    public class MainController : ControllerBase
    {

        [HttpGet]
        public FileContentResult Get(string file, string output = "jpg")
        {
            Byte[] imageBytes = Convert.FromBase64String(file);
            using(var stream = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(stream);
            }

var stream = new MemoryStream();
                image.Save(stream, format);
            return File(imageBytes, $"image/{output}");
        }
    }
}
