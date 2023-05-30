using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnowTextProject.Interface;

namespace SnowTextProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly ISize _size;
        public SizeController(ISize size)
        {
            _size = size;
        }

        [HttpGet("GetSizeList")]
        public async Task<IActionResult> GetSizeList()
        {
            try
            {
                var sizes = await _size.GetSizeList();
                if (sizes == null)
                {
                    return NotFound(new { Message = "No Result Found!" });
                }
                return Ok(sizes);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return BadRequest(new { Message = await _size.CommonMessage() });
            }
        }
    }
}
