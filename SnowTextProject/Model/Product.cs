using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowTextProject.Model
{
    public class Product
    {
        public int PRODUCT_ID { get; set; }
        public string PRODUCT_NAME { get; set; }
        public string IMAGE_NAME { get; set; }
        public byte[] IMAGE_DATA { get; set; }
        public string PHOTO_URL { get; set; }
        public int SIZE_ID { get; set; }
    }
}
