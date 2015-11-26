namespace Gw2Api.Core
{
    public interface IGw2ApiAuthEndPoint<T> where T : new()
    {
        T HandleRequest(string apiKey);
    }
}