using System;
using System.Drawing;
using System.IO;

namespace NorthWindCore.Classes.Helpers
{
    public class ImageHelpers
    {
        /// <summary>
        /// Converts a byte array to an image
        /// </summary>
        /// <param name="byteArray">byte array to convert</param>
        /// <returns>Image from byte array</returns>
        public static Image ByteArrayToImage(byte[] byteArray)
        {
           
            var converter = new ImageConverter();
            var image = (Image)converter.ConvertFrom(byteArray);

            return image;
        }
    }
}
