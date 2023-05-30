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
    public class PasswordResetController : ControllerBase
    {
        private readonly IPasswordReset _paswsreset;
        public PasswordResetController(IPasswordReset paswsreset)
        {
            _paswsreset = paswsreset;
        }

        [HttpGet("GetPasswordreset")]
        public async Task<IActionResult> GetPasswordreset()
        {
            try
            {
                var products = await _paswsreset.GetPasswordreset();
                if (products == null)
                {
                    return NotFound(new { Message = "No Result Found!" });
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return BadRequest(new { Message = await _paswsreset.CommonMessage() });
            }
        }
    }
}
