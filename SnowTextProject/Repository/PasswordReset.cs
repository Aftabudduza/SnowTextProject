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
    public class PasswordReset
    {
        private readonly string _conString;

        public PasswordReset()
        {
            _conString = DbContext.Connection;
        }
        internal async Task<IEnumerable<ForgetPassword>> GetProductList()
        {
            try
            {
                //string strSql = @"select  CAST(nvl(EMP_TITLE, '') AS VARCHAR(100)) || ' ' || CAST(EMP_NAME AS VARCHAR(500))|| '' ||EMP_CODE AS ENAME, el.*  
                //                from erp_pr_employee_list el  where el.CMP_BRANCH_ID = (select CMP_BRANCH_ID from ERP_CM_SYSTEM_USERS where sys_usr_id =  :sys_usr_id) ";
                //using var conn = new OracleConnection(_conString);
                //var param = new { sys_usr_id = userId };
                //var employee = await conn.QueryAsync<PrEmployeeList>(strSql, param);

                //return employee;

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
