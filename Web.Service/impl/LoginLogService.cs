using System;
using System.Collections.Generic;
using AutoMapper;
using Web.Model.Database;
using Web.Model.VO;
using Web.Repository;

namespace Web.Service.impl
{
    public class LoginLogService : ILoginLogService
    {
        private readonly ILoginLogRepository _loginLogRepository;
        private readonly IMapper _mapper;

        public LoginLogService(ILoginLogRepository loginLogRepository, IMapper mapper)
        {
            _loginLogRepository = loginLogRepository;
            _mapper = mapper;
        }

        public void Insert(LoginLog loginLog)
        {
            _loginLogRepository.Insert(loginLog);
        }

        public Tuple<int, IEnumerable<LoginLogVo>> GetLoginLogListToPage(LoginLog loginLog)
        {
            var count = 0;
            var s1 = _loginLogRepository.GetLoginLogListToPage(loginLog, ref count);
            var data = _mapper.Map<IEnumerable<LoginLogVo>>(s1);
            return new Tuple<int, IEnumerable<LoginLogVo>>(count, data);
        }
    }
}