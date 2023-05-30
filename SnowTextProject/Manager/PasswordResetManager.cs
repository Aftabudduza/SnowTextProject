using AutoMapper;
using SnowTextProject.Dtos;
using SnowTextProject.Interface;
using SnowTextProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowTextProject.Manager
{
    public class PasswordResetManager: IPasswordReset
    {
        private PasswordresetRepository _passwordRepository;
        private CommonRepository _commonRepository;
        private readonly IMapper _mapper;

        public PasswordResetManager(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<string> CommonMessage()
        {
            _commonRepository = new CommonRepository();
            return await _commonRepository.CommonMessage();
        }
        public async Task<IEnumerable<PasswordDto>> GetPasswordreset()
        {
            string strSysText = "";
            //string ClientIpAddress = "";
            try
            {

                _passwordRepository = new PasswordresetRepository();
                var products = await _passwordRepository.GetForgetPassword();
                var productList = _mapper.Map<IEnumerable<PasswordDto>>(products);
                return productList;
            }
            catch (Exception ex)
            {
                strSysText = ex.Message.ToString();
                throw new Exception(strSysText);
            }
            finally
            {

            }
        }
    }
}
