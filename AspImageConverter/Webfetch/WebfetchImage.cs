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
        public static async Task<MemoryStream> ByGetUrl(string path) {
            /* Declare the final result container as a MemoryStream */
            MemoryStream result = new();

            /* Create a new basic HttpWebRequest */
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(path);

            /* Start a try block to handle HttpWebRequest response errors */
            try {
                using (var res = await req.GetResponseAsync()){

                    /* Create a new BinaryReader to get the response content */
                    using (BinaryReader reader = new(res.GetResponseStream())) {
                        Byte[] bytes = reader.ReadBytes(int.MaxValue);
                        result = new MemoryStream(bytes, 0, bytes.Length);
                    }
                }
            }
            catch(Exception e) {
                throw new Exception(e);
            }
            /*
                Note: You can add customization to the exception handler insted of
                returning a void MemoryStream.
            */
            return result;
        }
    }
}