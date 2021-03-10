namespace Web.Service
{
    public interface IRedisService
    {
        void DelAsync(params string[] key);
    }
}