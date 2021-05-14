
using QLNVSSV.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QLNVSSV.Client.ApiIntergration
{
    public static class GetData<T>
    {
        public static async Task<List<T>> GetList(string url)
        {

            var listdata = new List<T>();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    listdata = (List<T>)JsonConvert.DeserializeObject(result, typeof(List<T>));
                }
            }
            return listdata;
        }


        public static async Task<List<T>> GetListPost(string url, ApprovalFillterViewModel approvalFillterViewModel)
        {
            var listdata = new List<T>();
            var json = JsonConvert.SerializeObject(approvalFillterViewModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(url, data);
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync();

                    listdata = (List<T>)JsonConvert.DeserializeObject(result.Result, typeof(List<T>));
                }
            }
            return listdata;
        }
    }
}
