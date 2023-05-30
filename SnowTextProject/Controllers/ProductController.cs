using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnowTextProject.Dtos;
using SnowTextProject.Interface;

namespace SnowTextProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;
        public ProductController(IProduct product)
        {
            _product = product;
        }

        [HttpPost("InsertProduct")]
        public async Task<IActionResult> InsertProduct(ProductDto productDto)
        {
            try
            {
                var result = await _product.InsertProduct(productDto, HttpContext);
                if (result == "Product Inserted")
                {
                    return Ok(new { Message = result });
                }
                else
                {
                    return BadRequest(new { Message = result });
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return BadRequest(new { Message = await _product.CommonMessage() });
            }
        }

        [HttpGet("GetProdctList")]
        public async Task<IActionResult> GetProductList()
        {
            try
            {
                var products = await _product.GetProductList(HttpContext);
                if (products == null)
                {
                    return NotFound(new { Message = "No Result Found!" });
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return BadRequest(new { Message = await _product.CommonMessage() });
            }
        }

        [HttpGet("GetProductById/{iProductId}")]
        public async Task<IActionResult> GetProductById(int iBrandId)
        {
            try
            {
                var products = await _product.GetProductById(HttpContext, iBrandId);
                if (products == null)
                {
                    return NotFound(new { Message = "No Result Found!" });
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return BadRequest(new { Message = await _product.CommonMessage() });
            }
        }

        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(ProductDto productDto)
        {
            try
            {
                var result = await _product.UpdateProduct(productDto, HttpContext);
                if (result == "Product Updated")
                {
                    return Ok(new { Message = result });
                }
                else
                {
                    return BadRequest(new { Message = result });
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return BadRequest(new { Message = await _product.CommonMessage() });
            }
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var brandDelete = await _product.DeleteProduct(id, HttpContext);
                return Ok(new { Message = brandDelete });
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return BadRequest(new { Message = await _product.CommonMessage() });
            }
        }
    }
}
