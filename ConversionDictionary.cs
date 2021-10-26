using System.Collections.Generic;
using System.Drawing.Imaging;

namespace AspImageConverter {
    public static class ConversionDictionary {
        static Dictionary<string, ImageFormat> MimeTypes = new Dictionary<string, ImageFormat>()
        {
            { "jpg", ImageFormat.Jpeg },
            { "jpeg", ImageFormat.Jpeg },
            { "bmp", ImageFormat.Bmp },
            { "png", ImageFormat.Png }
        };
    }
}