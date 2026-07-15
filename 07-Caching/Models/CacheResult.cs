namespace CSharpWinFormsPOCs._07_Caching.Models
{
    public class CacheResult<T>
    {
        public T Value { get; private set; }
        public bool IsCacheHit { get; private set; }

        public CacheResult(T value, bool isCacheHit)
        {
            Value = value;
            IsCacheHit = isCacheHit;
        }
    }
}