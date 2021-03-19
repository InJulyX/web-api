using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Web.Model.Database;

namespace Sms.Gateway
{
    public class Ue35 : IBaseGateway
    {
        /// <summary>
        /// 查询通道余额
        /// </summary>
        /// <param name="smsGateway"></param>
        /// <returns></returns>
        public string GetBalance(SmsGateway smsGateway)
        {
            throw new System.NotImplementedException();
        }

        public void SendMessage(SmsGateway smsGateway)
        {
            throw new System.NotImplementedException();
        }
        
    }
}