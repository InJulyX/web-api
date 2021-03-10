using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Web.Model;
using Web.Model.Database;
using Web.Model.VO;
using Web.Service;

namespace Web.Api.Controllers.Log
{
    [Route("/log/operaLog")]
    public class OperaLogController : BaseController
    {
        private readonly IOperaLogService _operaLogService;

        public OperaLogController(IOperaLogService operaLogService)
        {
            _operaLogService = operaLogService;
        }

        [HttpGet]
        [Route("list")]
        public AjaxResult<IEnumerable<OperaLogVo>> GetOperaLogListToPage(OperaLog operaLog)
        {
            var (item1, item2) = _operaLogService.GetOperaLogListToPage(operaLog);
            return AjaxResult<IEnumerable<OperaLogVo>>.Success(item1, item2);
        }
    }
}