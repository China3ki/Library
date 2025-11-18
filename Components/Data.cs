using Library.Models;
using Library.Models.User;
using Newtonsoft.Json;

namespace Library.Components
{
    static public class Data
    {
        static public async Task<T> GetData<T>(HttpClient client, string url)
        {
            var fetch = await client.GetAsync(url);
            if (!fetch.IsSuccessStatusCode) return default;

            var data = await fetch.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<T>(data);
            return json;
        }
    }
}
