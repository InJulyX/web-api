using System;
using System.Collections.Generic;
using AutoMapper;
using Web.Model.Database;
using Web.Model.VO;
using Web.Repository;

namespace Web.Service.impl
{
    public class OperaLogService : IOperaLogService
    {
        private readonly IMapper _mapper;
        private readonly IOperaLogRepository _operaLogRepository;

        public OperaLogService(IOperaLogRepository operaLogRepository, IMapper mapper)
        {
            _operaLogRepository = operaLogRepository;
            _mapper = mapper;
        }

        public Tuple<int, IEnumerable<OperaLogVo>> GetOperaLogListToPage(OperaLog operaLog)
        {
            var count = 0;
            var data = _operaLogRepository.GetOperaLogListToPage(operaLog, ref count);
            return new Tuple<int, IEnumerable<OperaLogVo>>(count, _mapper.Map<IEnumerable<OperaLogVo>>(data));
        }
    }
}