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
    public class SizeManager : ISize
    {
        private SizeRepository _sizeRepository;
        private CommonRepository _commonRepository;
        private readonly IMapper _mapper;
        public SizeManager(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<string> CommonMessage()
        {
            _commonRepository = new CommonRepository();
            return await _commonRepository.CommonMessage();
        }

        public async Task<IEnumerable<SizeDto>> GetSizeList()
        {
            string strSysText = "";
            try
            {
                _sizeRepository = new SizeRepository();
                var sizes = await _sizeRepository.GetSizeList();
                var sizeList = _mapper.Map<IEnumerable<SizeDto>>(sizes);
                return sizeList;
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
    }
}
