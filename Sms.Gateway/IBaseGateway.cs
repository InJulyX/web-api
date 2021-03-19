using Web.Model.Database;

namespace Sms.Gateway
{
    public interface IBaseGateway
    {
        /// <summary>
        /// 查询通道余额
        /// </summary>
        /// <returns></returns>
        string GetBalance(SmsGateway smsGateway);

        void SendMessage(SmsGateway smsGateway);
    }
}