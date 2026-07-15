using CSharpWinFormsPOCs._07_Caching.Models;
using CSharpWinFormsPOCs._07_Caching.Repositories;
using System;
using System.Runtime.Caching;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpWinFormsPOCs._07_Caching.Services
{
    public class CustomerCacheService
    {
        private readonly ObjectCache _cache;
        private readonly ICustomerRepository _repository;
        private readonly TimeSpan _expiration;

        private int _cacheHits;
        private int _cacheMisses;

        public int CacheHits
        {
            get { return _cacheHits; }
        }

        public int CacheMisses
        {
            get { return _cacheMisses; }
        }

        public CustomerCacheService(
            ObjectCache cache,
            ICustomerRepository repository,
            TimeSpan expiration)
        {
            if (cache == null)
                throw new ArgumentNullException("cache");

            if (repository == null)
                throw new ArgumentNullException("repository");

            _cache = cache;
            _repository = repository;
            _expiration = expiration;
        }

        public async Task<CacheResult<Customer>> GetAsync(
            string customerId)
        {
            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentException(
                    "Customer ID is required.",
                    "customerId");
            }

            string key = CreateCacheKey(customerId);

            Lazy<Task<Customer>> cachedValue =
                _cache.Get(key) as Lazy<Task<Customer>>;

            if (cachedValue != null)
            {
                Interlocked.Increment(ref _cacheHits);

                Customer cachedCustomer =
                    await cachedValue.Value;

                return new CacheResult<Customer>(
                    cachedCustomer,
                    true);
            }

            Lazy<Task<Customer>> newValue =
                new Lazy<Task<Customer>>(
                    delegate
                    {
                        return _repository.GetCustomerAsync(
                            customerId);
                    },
                    LazyThreadSafetyMode.ExecutionAndPublication);

            CacheItemPolicy policy = new CacheItemPolicy
            {
                AbsoluteExpiration =
                    DateTimeOffset.Now.Add(_expiration)
            };

            Lazy<Task<Customer>> existingValue =
                _cache.AddOrGetExisting(
                    key,
                    newValue,
                    policy) as Lazy<Task<Customer>>;

            Lazy<Task<Customer>> selectedValue =
                existingValue ?? newValue;

            bool isCacheHit = existingValue != null;

            if (isCacheHit)
                Interlocked.Increment(ref _cacheHits);
            else
                Interlocked.Increment(ref _cacheMisses);

            try
            {
                Customer customer = await selectedValue.Value;

                return new CacheResult<Customer>(
                    customer,
                    isCacheHit);
            }
            catch
            {
                // Avoid caching a failed task.
                _cache.Remove(key);
                throw;
            }
        }

        public async Task<CacheResult<Customer>> RefreshAsync(
            string customerId)
        {
            Remove(customerId);
            return await GetAsync(customerId);
        }

        public void Remove(string customerId)
        {
            _cache.Remove(CreateCacheKey(customerId));
        }

        public void Clear()
        {
            foreach (var item in _cache)
                _cache.Remove(item.Key);

            Interlocked.Exchange(ref _cacheHits, 0);
            Interlocked.Exchange(ref _cacheMisses, 0);
        }

        private static string CreateCacheKey(
            string customerId)
        {
            return "customer:" +
                   customerId.Trim().ToLowerInvariant();
        }
    }
}