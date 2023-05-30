using Dapper;
using SnowTextProject.Common;
using SnowTextProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SnowTextProject.Repository
{
    public class SizeRepository
    {
        private readonly string _conString;
        public SizeRepository()
        {
            _conString = DbContext.Connection;
        }
        internal async Task<IEnumerable<Size>> GetSizeList()
        {
            try
            {
                string strSql = "SELECT * FROM SN_SIZE WHERE ISDELETE=@ISDELETE ORDER BY SIZE_ID DESC";
                var parameter = new
                {
                    ISDELETE = 0
                };

                var conn = new SqlConnection(_conString);
                var sizeList = await conn.QueryAsync<Size>(strSql, parameter);

                return sizeList.ToList();
            }
            catch (Exception ex)
            {
                string strResult = ex.Message.ToString();
                throw new Exception(strResult);
            }
        }
    }
}
