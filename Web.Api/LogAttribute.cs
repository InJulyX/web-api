using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Web.Model.Database;
using Web.Repository;

namespace Web.Api
{
    public class LogAttribute : Attribute, IAsyncActionFilter
    {
        public LogAttribute(string title, string operaType)
        {
            Title = title;
            OperaType = operaType;
        }

        private string Title { get; }
        private string OperaType { get; }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var username = context.HttpContext.User.Claims.FirstOrDefault(o => o.Type == "username")?.Value;
            var userId = context.HttpContext.User.Claims.FirstOrDefault(o => o.Type == "user_id")?.Value;
            var method = context.HttpContext.Request.Method;
            var path = context.HttpContext.Request.Path.Value;
            var clientIp = context.HttpContext.Connection.RemoteIpAddress?.ToString();
            var operaLog = new OperaLog
            {
                Username = username,
                Method = method,
                Path = path,
                ClientIp = clientIp,
                Type = OperaType,
                Module = Title,
                UserId = Convert.ToInt64(userId)
            };

            try
            {
                var param = context.ActionArguments.First().Value;
                operaLog.Params = JsonConvert.SerializeObject(param,
                    new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
            }
            catch (Exception)
            {
                operaLog.Params = string.Empty;
            }

            ServiceLocator.Instance.GetService<IOperaLogRepository>()?.Insert(operaLog);
            await next.Invoke();
        }
    }
}