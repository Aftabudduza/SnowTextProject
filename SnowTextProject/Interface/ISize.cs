using SnowTextProject.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowTextProject.Interface
{
    public interface ISize
    {
        Task<IEnumerable<SizeDto>> GetSizeList();
        Task<string> CommonMessage();
    }
}
