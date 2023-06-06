namespace TP.Domain.Interfaces.Services
{
    public interface ICacheControlService
    {
        public void SettingTimeAndCache(object cacheObject, string cacheKey, int timeToLive = 10);
    }
}
