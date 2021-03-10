using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Web.Common;
using Web.Model;
using Web.Model.Database;
using Web.Model.VO;
using Web.Service;

namespace Web.Api.Controllers.Log
{
    [Route("/log/loginLog")]
    public class LoginLogController : BaseController
    {
        private readonly ILoginLogService _loginLogService;

        public LoginLogController(ILoginLogService loginLogService)
        {
            _loginLogService = loginLogService;
        }

        /// <summary>
        ///     查询登录日志列表
        /// </summary>
        /// <param name="loginLog"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        public AjaxResult<IEnumerable<LoginLogVo>> GetLoginListToPage(LoginLog loginLog)
        {
            var (item1, item2) = _loginLogService.GetLoginLogListToPage(loginLog);
            return AjaxResult<IEnumerable<LoginLogVo>>.Success(item1, item2);
        }
    }
}