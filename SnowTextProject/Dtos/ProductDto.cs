using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowTextProject.Dtos
{
    public class ProductDto
    {
        public int ProuctId { get; set; }
        public string ProductName { get; set; }
        public string ImageName { get; set; }
        public string PhotoUrl { get; set; }
        public byte[] ImageData { get; set; }
        public int SizeId { get; set; }
    }
}
