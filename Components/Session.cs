using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Library.Components
{
    static public class Session
    {
        static public async Task StartSession(HttpClient client, HttpContext context, string email)
        {
            // Error?
            SessionModel data = await GetSessionData(client, email);
            context.Session.SetInt32("Id", data.UserId);
            context.Session.SetString("Nickname", data.UserNick);
            Console.WriteLine(data.UserImage);
            context.Session.SetString("Avatar", data.UserImage);
        }
        static public async void EndSession(HttpContext context) => context.Session.Clear();
        static private async Task<SessionModel> GetSessionData(HttpClient client, string email)
        {
            var fetch = await client.GetAsync($"api/Users/session/{email}");
            //if(!data.IsSuccessStatusCode)
            var data = await fetch.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<SessionModel>(data);
            return json;
        }
    }
}
