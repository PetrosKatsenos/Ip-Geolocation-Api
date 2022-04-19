using CommonLibraries.Interfaces;
using Newtonsoft.Json;

namespace CommonLibraries
{
    public class HttpHelper : IHttpHelper
    {
        public async Task<T> GetAsync<T>(string url) where T : class
        {
            using (var httpClient = new HttpClient())
            {
                var responseMessage = await httpClient.GetAsync(url);
                responseMessage.EnsureSuccessStatusCode();

                var content = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
        }
    }
}