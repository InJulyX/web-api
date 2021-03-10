using System.Threading.Tasks;

namespace Web.Common
{
    public interface IRedisHelper
    {
        string Get(string key);
        Task<string> GetAsync(string key);
        T Get<T>(string key) where T : new();
    }

    public class RedisClient : IRedisHelper
    {
        public string Get(string key)
        {
            return RedisHelper.Get(key);
        }

        public Task<string> GetAsync(string key)
        {
            return RedisHelper.GetAsync(key);
        }

        public T Get<T>(string key) where T : new()
        {
            return RedisHelper.Get<T>(key);
        }
    }
}