namespace Web.Service.impl
{
    public class RedisService : IRedisService
    {
        public void DelAsync(params string[] key)
        {
            var s1 = RedisHelper.DelAsync(key);
        }
    }
}