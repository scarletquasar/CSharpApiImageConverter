using System.Collections.Generic;
using System.Drawing.Imaging;

namespace AspImageConverter.Conversion {
    public static class ConversionDictionary {
        public static Dictionary<string, ImageFormat> MimeTypes = new()
        {
            { "jpg", ImageFormat.Jpeg },
            { "jpeg", ImageFormat.Jpeg },
            { "bmp", ImageFormat.Bmp },
            { "png", ImageFormat.Png }
        };
    }
}