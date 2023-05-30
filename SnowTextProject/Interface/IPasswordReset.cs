using Microsoft.AspNetCore.Http;
using SnowTextProject.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowTextProject.Interface
{
   public interface IPasswordReset
    {
        Task<IEnumerable<PasswordDto>> GetPasswordreset();
        Task<string> CommonMessage();
    }
}
