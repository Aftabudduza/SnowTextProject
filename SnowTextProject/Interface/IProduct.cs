using Microsoft.AspNetCore.Http;
using SnowTextProject.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowTextProject.Interface
{
    public interface IProduct
    {
        Task<string> InsertProduct(ProductDto productDto, HttpContext httpContext);
        Task<IEnumerable<ProductDto>> GetProductList(HttpContext httpContext);
        Task<ProductDto> GetProductById(HttpContext httpContext, int iBrandId);
        Task<string> DeleteProduct(int id, HttpContext httpContext);
        Task<string> UpdateProduct(ProductDto productdDto, HttpContext httpContext);
        Task<string> CommonMessage();
    }
}
