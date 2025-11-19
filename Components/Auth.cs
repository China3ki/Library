using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Library.Components
{
    static public class Auth
    {
        static public async Task<bool> Login(HttpClient client, LoginDto login)
        {
            string json = JsonConvert.SerializeObject(login);
            StringContent data = new(json, Encoding.UTF8, "application/json");
            var fetch = await client.PostAsync("/api/Auth/login", data);
            if (fetch.IsSuccessStatusCode) return true;
            else return false;
        }
        static public async Task<bool> Register(HttpClient client, RegisterDto register)
        {
            string json = JsonConvert.SerializeObject(register);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            var fetch = await client.PostAsync("/api/Auth/register", data);
            if (fetch.IsSuccessStatusCode) return true;
            else return false;
        }
        static public bool CheckAdmin(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Session.GetString("Id")) || bool.Parse(context.Session.GetString("Admin")) == false) return false;
            return true;
        }
    }
}
