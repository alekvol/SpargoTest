using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpargoTest.Services.Authorization;

namespace SpargoTest.Services
{
    internal class GettingGoods
    {
        // создаем http-клиент
        internal static HttpClient CreateClient(string accessToken = "")
        {
            var client = new HttpClient();
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            }
            return client;
        }
        // Получение номеклатур
        /// <summary>
        /// Получение номеклатур
        /// </summary>
        /// <param name="token"> Токен авторизации</param>
        /// <param name="department"> Индефикатор департамента </param>
        /// <returns></returns>
        internal static string GetGoods(string token, string? department)
        {
            using (var client = CreateClient(token))
            {
                try
                {
                    var response = client.GetAsync(APP_PATH + $"/Goods/{department}").Result;
                    return response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
            }
        }
    }
}
