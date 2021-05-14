using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace QLNVSSV.Client.ApiIntergration
{
    public static class GetDataFromHeader<T>
    {
        public static async Task<T> GetData(string url)
        {
            var instance = Activator.CreateInstance<T>();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                var x = response.Headers.GetValues("X-Pagination").First();
                if (response.IsSuccessStatusCode)
                {

                    instance = JsonSerializer.Deserialize<T>(response.Headers.GetValues("X-Pagination").First(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
            }
            return instance;
        }
    }
}
