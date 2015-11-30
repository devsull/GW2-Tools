namespace Gw2Api.Core.EndPoints
{
    public interface IGw2ApiAuthEndPoint<T> where T : new()
    {
        T HandleRequest(string apiKey, string resourceEndPoint = null);
    }
}