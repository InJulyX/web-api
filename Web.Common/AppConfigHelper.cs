using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Web.Common
{
    /// <summary>
    /// 读取配置文件
    /// </summary>
    public  class AppConfigHelper
    {
        public static IConfiguration Configuration { get; }

        static AppConfigHelper()
        {
            // ReloadOnChange = true  当appsettings.json 被修改时重新加载
            Configuration = new ConfigurationBuilder()
                .Add(new JsonConfigurationSource {Path = "appsettings.json", ReloadOnChange = true})
                .Build();
        }
    }
}