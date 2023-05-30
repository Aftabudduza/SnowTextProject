using SnowTextProject.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SnowTextProject.Repository
{
    public class CommonRepository
    {
        private readonly string _conString;
        private ServiceHandler _serviceHandler;
        public CommonRepository()
        {
            _conString = DbContext.Connection;
        }

        internal async Task<string> CommonMessage()
        {
            _serviceHandler = new ServiceHandler();
            return await _serviceHandler.CommonMessage();
        }

        internal async Task<string> SaveImageDirectory(string FileName, byte[] ImageData, string imageFormate = "jpeg")
        {
            string result = "";
            Image img;
            try
            {
                // byte[] bytes = Convert.FromBase64String(imagedata);
                using (MemoryStream imgStream = new MemoryStream(ImageData))
                {
                    img = Image.FromStream(imgStream);
                }
                Bitmap b = new Bitmap(img);

                Graphics g;
                using (g = Graphics.FromImage(b))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                    g.DrawImage(img, new Point(0, 0));
                }

                //string filepath = AppDomain.CurrentDomain.BaseDirectory + "images\\" + FirstFileName + ".jpg";

                string ImageName = FileName.Replace(" ", "_");
                string filepath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\", ImageName);

                float thumbWidth = 3000F;
                float thumbHeight = 2500F;

                if (img.Width > img.Height)
                {
                    thumbHeight = ((float)img.Height / img.Width) * thumbWidth;
                }
                else
                {
                    thumbWidth = ((float)img.Width / img.Height) * thumbHeight;
                }

                int actualthumbWidth = Convert.ToInt32(Math.Floor(thumbWidth));
                int actualthumbHeight = Convert.ToInt32(Math.Floor(thumbHeight));
                var thumbnailBitmap = new Bitmap(actualthumbWidth, actualthumbHeight);
                var thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
                thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, actualthumbWidth, actualthumbHeight);
                thumbnailGraph.DrawImage(img, imageRectangle);
                var ms = new MemoryStream();
                ImageFormat format;
                switch (imageFormate)
                {
                    case "icon": format = ImageFormat.Icon; break;
                    case "png": format = ImageFormat.Png; break;
                    case "gif": format = ImageFormat.Gif; break;
                    default: format = ImageFormat.Jpeg; break;
                }
                thumbnailBitmap.Save(filepath, format);
                ms.Position = 0;
                GC.Collect();
                thumbnailGraph.Dispose();
                thumbnailBitmap.Dispose();
                img.Dispose();

                //img = b;
                //img.Save(filepath, ImageFormat.Jpeg);
                //graphics.Save(filepath, ImageFormat.Jpeg);
                result = ImageName;
                //result = filepath;
                //----------------------------
            }
            catch (Exception ex)
            {

                result = ex.Message.ToString();
            }
            return result;
        }
    }
}
