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
    public class ProductRepository
    {
        private readonly string _conString;

        public ProductRepository()
        {
            _conString = DbContext.Connection;
        }

        internal async Task<bool> IsExist(string ProductName)
        {
            bool Result = true;
            try
            {
                string strSql = "SELECT * FROM SN_PRODUCT WHERE PRODUCT_NAME=@PRODUCT_NAME";

                var parameter = new
                {
                    PRODUCT_NAME = ProductName,
                };

                var conn = new SqlConnection(_conString);
                var brand = await conn.QueryAsync<Product>(strSql, parameter);
                if (brand.Count() > 0)
                {
                    Result = false;
                }

            }
            catch (Exception ex)
            {
                string strResult = ex.Message.ToString();
                throw new Exception(strResult);
            }
            return Result;
        }

        internal async Task<Product> InsertProduct(Product product)
        {
            try
            {
                string strSql = "INSERT INTO SN_PRODUCT (PRODUCT_NAME,PHOTO_URL, SIZE_ID) VALUES (@PRODUCT_NAME,@PHOTO_URL,@SIZE_ID)";

                var parameter = new
                {
                    product.PRODUCT_NAME,
                    product.PHOTO_URL,
                    product.SIZE_ID,
                };

                var conn = new SqlConnection(_conString);
                var brand = await conn.QueryAsync<Product>(strSql, parameter);

                return brand.FirstOrDefault();
            }
            catch (Exception ex)
            {
                string strResult = ex.Message.ToString();
                throw new Exception(strResult);
            }
        }

        internal async Task<IEnumerable<Product>> GetProductList()
        {
            try
            {
                string strSql = "SELECT * FROM SN_PRODUCT WHERE ISDELETE=@ISDELETE ORDER BY PRODUCT_ID DESC";
                var parameter = new
                {
                    ISDELETE = 0
                };

                var conn = new SqlConnection(_conString);
                var productList = await conn.QueryAsync<Product>(strSql, parameter);

                return productList.ToList();
            }
            catch (Exception ex)
            {
                string strResult = ex.Message.ToString();
                throw new Exception(strResult);
            }
        }

        internal async Task<Product> GetBrandById(int iBrandId)
        {
            try
            {
                string strSql = "SELECT * FROM BRAND_LIST WHERE BRAND_ID=@BRAND_ID AND ISDELETE=@ISDELETE";

                var parameter = new
                {
                    BRAND_ID = iBrandId,
                    ISDELETE = 0
                };

                var conn = new SqlConnection(_conString);
                var brand = await conn.QuerySingleAsync<Product>(strSql, parameter);

                return brand;
            }
            catch (Exception ex)
            {
                string strResult = ex.Message.ToString();
                throw new Exception(strResult);
            }
        }
        internal async Task<Product> UpdateBrand(Product productData)
        {
            try
            {
                string strSubSql = "";

                if (productData.PHOTO_URL != "")
                {
                    strSubSql += " PHOTO_URL=@PHOTO_URL,";
                }

                string strSql = "UPDATE SN_PRODUCT SET " + strSubSql + " PRODUCT_NAME=@PRODUCT_NAME,SIZE_ID=@SIZE_ID WHERE PRODUCT_ID=@PRODUCT_ID";

                var parameter = new
                {
                    productData.PRODUCT_NAME,
                    productData.PHOTO_URL,
                    productData.SIZE_ID
                };

                var conn = new SqlConnection(_conString);
                var product = await conn.QueryAsync<Product>(strSql, parameter);

                return product.FirstOrDefault();
            }
            catch (Exception ex)
            {
                string strResult = ex.Message.ToString();
                throw new Exception(strResult);
            }
        }
        internal async Task<Product> DeleteBrand(int id)
        {
            try
            {
                string strSql = "UPDATE SN_PRODUCT SET ISDELETE=@ISDELETE WHERE PRODUCT_ID=@PRODUCT_ID";

                var parameter = new
                {
                    PRODUCT_ID = id,
                    ISDELETE = 1
                };


                var conn = new SqlConnection(_conString);
                var branddelete = await conn.QueryAsync<Product>(strSql, parameter);

                return branddelete.FirstOrDefault();
            }
            catch (Exception ex)
            {
                string strResult = ex.Message.ToString();
                throw new Exception(strResult);
            }
        }
    }
}
