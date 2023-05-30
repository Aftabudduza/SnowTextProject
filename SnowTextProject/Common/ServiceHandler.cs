using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SnowTextProject.Common
{
    public class ServiceHandler
    {
        internal async Task<string> CommonMessage()
        {
            return await Task.FromResult("Something went wrong!");
        }
        public async Task<string> Upload_Images(string fileName, byte[] imagedata, string path)
        {
            string result = "";

            Image img;
            try
            {
                using (MemoryStream imgStream = new MemoryStream(imagedata))
                {
                    img = Image.FromStream(imgStream);
                }
                Bitmap b = new Bitmap(img);

                string imagePath = path + fileName;
                b.Save(imagePath);
                result = "000";
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                result = "Failed";
            }
            return await Task.FromResult(result);
        }
        public async Task<string> Get_Images64String(string fileName, string path)
        {
            string base64String = null;

            try
            {
                string imagePath = path + fileName;

                using (Image image = Image.FromFile(imagePath))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();

                        // Convert byte[] to Base64 String
                        base64String = Convert.ToBase64String(imageBytes);
                        // result = base64String;
                        // result = imageBytes;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return await Task.FromResult(base64String);
        }
        public async Task<byte[]> Get_Images(string fileName, string path)
        {
            byte[] result = null;

            try
            {
                string imagePath = path + fileName;

                using (Image image = Image.FromFile(imagePath))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();

                        // Convert byte[] to Base64 String
                        string base64String = Convert.ToBase64String(imageBytes);
                        // result = base64String;
                        result = imageBytes;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                result = null;
            }
            return await Task.FromResult(result);
        }

        internal async Task<string> GetDateStringFromUTC(string strDate, string strFormat)
        {
            string date = Convert.ToDateTime(strDate.Substring(0, strDate.IndexOf('G'))).ToString(strFormat);
            return await Task.FromResult(date);
        }
    }
}
