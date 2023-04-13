using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SpargoTest.Services
{
    public static class Authorization
    {
        internal const string APP_PATH = "http://f3bus.test.pharmadata.ru";
        internal static string token;
        internal static string expiration;

        // Авторизация
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns> Статус код http</returns>
        public static string Authorize(string login, string password)
        {
            var registerModel = new
            {
                Login = login,
                Password = password,

            };

            using (var client = new HttpClient())
            {

                var response = client.PostAsJsonAsync(APP_PATH + "/User/auth/Agent", registerModel).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                Dictionary<string, string> tokenDictionary =
                    JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                token = tokenDictionary["token"];
                expiration = tokenDictionary["expiration"];
                return response.StatusCode.ToString();
            }
        }
    }
}
