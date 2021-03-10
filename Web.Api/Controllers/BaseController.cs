using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected string GetUserName()
        {
            var username = User.Claims.FirstOrDefault(o => o.Type == "username")?.Value;
            return username;
        }

        protected long GetUserId()
        {
            // s1.Claims.FirstOrDefault(o=>o.Type=="user_id")?.Value
            var s1 = User.Claims.FirstOrDefault(o => o.Type == "user_id")?.Value;
            return Convert.ToInt64(s1);
        }

        protected string GetClientIp()
        {
            var s1 = Request.HttpContext.Connection.RemoteIpAddress?.ToString();
            return s1;
        }
    }
}