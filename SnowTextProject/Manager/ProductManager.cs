using AutoMapper;
using Microsoft.AspNetCore.Http;
using SnowTextProject.Dtos;
using SnowTextProject.Interface;
using SnowTextProject.Model;
using SnowTextProject.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SnowTextProject.Manager
{
    public class ProductManager : IProduct
    {
        private ProductRepository _productRepository;
        private CommonRepository _commonRepository;
        private readonly IMapper _mapper;

        public ProductManager(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<string> CommonMessage()
        {
            _commonRepository = new CommonRepository();
            return await _commonRepository.CommonMessage();
        }

        public async Task<string> InsertProduct(ProductDto productDto, HttpContext httpContext)
        {
            string strSysText = "";
            string ClientIpAddress = "";
            try
            {
                ClientIpAddress = httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                var productData = _mapper.Map<Product>(productDto);
                _commonRepository = new CommonRepository();

                productData.PHOTO_URL = productData.PRODUCT_NAME.Replace(" ", "-");

                _productRepository = new ProductRepository();
                bool isExist = await _productRepository.IsExist(productDto.ProductName);

                if (isExist)
                {
                    var random = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(productData.IMAGE_NAME);
                    productData.PHOTO_URL = await _commonRepository.SaveImageDirectory(random + extension, productData.IMAGE_DATA);

                    var product = await _productRepository.InsertProduct(productData);

                    var brandMapper = _mapper.Map<ProductDto>(product);

                    strSysText = "Product Inserted";
                }
                else
                {
                    strSysText = "Product Already Exist!";
                }
                return strSysText;
            }
            catch (Exception ex)
            {
                strSysText = ex.Message.ToString();
                return strSysText;
            }
            finally
            {
                //RequestDetaildto requestDetailDto = new RequestDetaildto();
                //_commonRepository = new CommonRepository();
                //requestDetailDto.ClientIPAddress = ClientIpAddress;
                //requestDetailDto.ActionName = this.GetType().FullName;
                //requestDetailDto.OperationType = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
                //await _commonRepository.SystemAudit(requestDetailDto, strSysText);
            }
        }

        public async Task<IEnumerable<ProductDto>> GetProductList(HttpContext httpContext)
        {
            string strSysText = "";
            string ClientIpAddress = "";
            try
            {
                ClientIpAddress = httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                _productRepository = new ProductRepository();
                var products = await _productRepository.GetProductList();
                var productList = _mapper.Map<IEnumerable<ProductDto>>(products);
                return productList;
            }
            catch (Exception ex)
            {
                strSysText = ex.Message.ToString();
                throw new Exception(strSysText);
            }
            finally
            {
                //RequestDetaildto requestDetailDto = new RequestDetaildto();
                //_commonRepository = new CommonRepository();
                //requestDetailDto.ClientIPAddress = ClientIpAddress;
                //requestDetailDto.ActionName = this.GetType().FullName;
                //requestDetailDto.OperationType = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
                //await _commonRepository.SystemAudit(requestDetailDto, strSysText);
            }
        }

        public async Task<ProductDto> GetProductById(HttpContext httpContext, int iProductId)
        {
            string strSysText = "";
            string ClientIpAddress = "";
            try
            {
                ClientIpAddress = httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                _productRepository = new ProductRepository();
                var product = await _productRepository.GetBrandById(iProductId);
                var productData = _mapper.Map<ProductDto>(product);
                return productData;
            }
            catch (Exception ex)
            {
                strSysText = ex.Message.ToString();
                throw new Exception(strSysText);
            }
            finally
            {
                //RequestDetaildto requestDetailDto = new RequestDetaildto();
                //_commonRepository = new CommonRepository();
                //requestDetailDto.ClientIPAddress = ClientIpAddress;
                //requestDetailDto.ActionName = this.GetType().FullName;
                //requestDetailDto.OperationType = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
                //await _commonRepository.SystemAudit(requestDetailDto, strSysText);
            }
        }

        public async Task<string> UpdateProduct(ProductDto productDto, HttpContext httpContext)
        {
            string strSysText = "";
            string ClientIpAddress = "";
            try
            {
                ClientIpAddress = httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                _commonRepository = new CommonRepository();

                var productData = _mapper.Map<Product>(productDto);
                _commonRepository = new CommonRepository();

                productData.PHOTO_URL = productData.PRODUCT_NAME.Replace(" ", "-");


                _productRepository = new ProductRepository();

                if (productData.IMAGE_NAME != "")
                {
                    var random = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(productData.IMAGE_NAME);
                    productData.IMAGE_NAME = await _commonRepository.SaveImageDirectory(random + extension, productDto.ImageData);
                }


                await _productRepository.UpdateBrand(productData);

                strSysText = productData.PRODUCT_NAME + "Successfully Updated";

                return strSysText;
            }
            catch (Exception ex)
            {
                strSysText = ex.Message.ToString();
                throw new Exception(strSysText);
            }
            finally
            {
                //RequestDetaildto requestDetailDto = new RequestDetaildto();
                //_commonRepository = new CommonRepository();
                //requestDetailDto.ClientIPAddress = ClientIpAddress;
                //requestDetailDto.ActionName = this.GetType().FullName;
                //requestDetailDto.OperationType = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
                //await _commonRepository.SystemAudit(requestDetailDto, strSysText);
            }
        }

        public async Task<string> DeleteProduct(int id, HttpContext httpContext)
        {
            string strSysText = "";
            string ClientIpAddress = "";
            try
            {
                ClientIpAddress = httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                _productRepository = new ProductRepository();

                var brand = await _productRepository.DeleteBrand(id);

                strSysText = "Product Deleted";
                return strSysText;
            }
            catch (Exception ex)
            {
                strSysText = ex.Message.ToString();
                throw new Exception(strSysText);
            }
            finally
            {
                //RequestDetaildto requestDetailDto = new RequestDetaildto();
                //requestDetailDto.ClientIPAddress = ClientIpAddress;
                //requestDetailDto.ActionName = this.GetType().FullName;
                //requestDetailDto.OperationType = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
                //_commonRepository = new CommonRepository();
                //await _commonRepository.SystemAudit(requestDetailDto, strSysText);
            }
        }
    }
}
