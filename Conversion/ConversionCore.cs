using System;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace AspImageConverter.Conversion {
    public static class ConversionCore {
        public static async Task<MemoryStream> GetStream(string file, string output) {
            return await Task.Run(() => {
                
                /* Declare the final result container as a MemoryStream */
                MemoryStream streamConverted = new MemoryStream();

                /* Convert the received Base64 to a byte array */
                Byte[] imageBytes = Convert.FromBase64String(file);

                /* Create a context using a memory stream to the raw bytes of the image */
                using(var streamRaw = new MemoryStream(imageBytes, 0, imageBytes.Length))
                {
                    /* Create a Image object using the raw image MemoryStream */
                    Image image = Image.FromStream(streamRaw);

                    /* 
                        Save the raw image in the new MemoryStream created in the beginning using
                        the ConversionDictionary to apply the output argument
                    */
                    image.Save(streamConverted, ConversionDictionary.MimeTypes[output]);
                }

                return streamConverted;
            });
        }
    }
}