using System.Collections.Generic;
using System.Drawing.Imaging;

namespace AspImageConverter {
    public static class ConversionDictionary {
        static Dictionary<string, ImageFormat> MimeTypes = new Dictionary<string, ImageFormat>()
        {
            { "jpg", ImageFormat.Jpeg },
            { "{appPath}", AppPath }
        };
    }
}