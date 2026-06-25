using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharpWinFormsPOCs
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task LoadUsers(Action<string> onSuccess, Action<Exception> onError)
        {
            try
            {
                // simulate slow network start
                await Task.Delay(3000);

                string json = await _httpClient.GetStringAsync(
                    "https://jsonplaceholder.typicode.com/users");

                onSuccess?.Invoke(json);
            }
            catch (Exception ex)
            {
                onError?.Invoke(ex);
            }
        }
    }
}