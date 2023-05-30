using Dapper;
using Oracle.ManagedDataAccess.Client;
using SnowTextProject.Common;
using SnowTextProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowTextProject.Repository
{
    public class PasswordresetRepository
    {
        private readonly string _conString;

        public PasswordresetRepository()
        {
            _conString = DbContext.Connection;
        }
        internal async Task<IEnumerable<ForgetPassword>> GetForgetPassword()
        {
            try
            {
                string strSql = "SELECT * FROM PASSWORD_RESET";
                var parameter = new
                {
                    ISDELETE = 0
                };

                var conn = new OracleConnection(_conString);
                var PasswordlisttList = await conn.QueryAsync<ForgetPassword>(strSql, parameter);

                return PasswordlisttList.ToList();
            }
            catch (Exception ex)
            {
                string strResult = ex.Message.ToString();
                throw new Exception(strResult);
            }
        }
    }
}
