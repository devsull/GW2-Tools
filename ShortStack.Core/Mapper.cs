
namespace ShortStack.Core
{
    using Nelibur.ObjectMapper;

    public static class Mapper
    {
        public static TDest Map<TSrc, TDest>(TSrc source) where TDest : class
        {
            return TinyMapper.Map<TDest>(source);
        }
    }
}