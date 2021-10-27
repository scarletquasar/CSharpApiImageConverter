using System.Net;
using System.IO;
using System;
using System.Threading.Tasks;

/*
    Note: The "WebfetchImage" method will not make a validation to check
    if the response file is really a IMAGE file, this will be made by the
    "ImageConverter" class during the conversion process.
*/
namespace AspImageConverter.Webfetch {
    public static class WebfetchImage {
        public static async Task<Byte[]> ByGetUrl(string path) {
            return await Task.Run(() => {
                /* Declare the final result container as a MemoryStream */
                Byte[] imageBytes = default;
                /* Start a try block to handle WebClient response errors */
                try {
                    
                    using (var webClient = new WebClient()) {
                        imageBytes = webClient.DownloadData(path);
                    }
                }
                catch {}
                /*
                    Note: You can add customization to the exception handler insted of
                    returning a void MemoryStream.
                */
                return imageBytes;
            });
        }
    }
}