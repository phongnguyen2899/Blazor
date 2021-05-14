using AntDesign;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace QLNVSSV.Client.Pages
{
    public partial class AntLibrary
    {
        string teram { get; set; }
        int pageIndex = 1;

        int pageSize = 2;

        int total { get; set; }

        List<QLNVSSV.Models.Modes.Employee> listEmployee { get; set; } = new();

        QLNVSSV.ViewModels.Common.ServiceResponse serviceResponse { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            serviceResponse =await GetTotalRecord();
            listEmployee = await ApiIntergration.GetData<QLNVSSV.Models.Modes.Employee>.GetList($"http://localhost:37919/api/Employee/GetPaging1?PageNumber={pageIndex}&pageSize={pageSize}");
        }

        private async Task<QLNVSSV.ViewModels.Common.ServiceResponse> GetTotalRecord()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:37919/api/Employee/GetCount");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    serviceResponse = (QLNVSSV.ViewModels.Common.ServiceResponse)JsonConvert.DeserializeObject(result, typeof(QLNVSSV.ViewModels.Common.ServiceResponse));
                }
            }
            return serviceResponse;
        }

        public async Task changeOnPage(PaginationEventArgs e)
        {
            pageIndex = Convert.ToInt32(e.Page);
            listEmployee = await ApiIntergration.GetData<QLNVSSV.Models.Modes.Employee>.GetList($"http://localhost:37919/api/Employee/GetPaging1?Search={teram}&PageNumber={Convert.ToInt32(e.Page)}&pageSize={pageSize}");
        }

        public async Task Calback(string search)
        {
            var a = await GetData($"http://localhost:37919/api/Employee/GetPaging1?Search={search}&PageNumber={Convert.ToInt32(pageIndex)}&pageSize={pageSize}");

            listEmployee = await ApiIntergration.GetData<QLNVSSV.Models.Modes.Employee>.GetList($"http://localhost:37919/api/Employee/GetPaging1?Search={search}&PageNumber={Convert.ToInt32(pageIndex)}&pageSize={pageSize}");
            serviceResponse.Data = a;
        }

        public static async Task<int> GetData(string url)
        {
            int totalrecord=0;
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                
                if (response.IsSuccessStatusCode)
                {

                    totalrecord = JsonSerializer.Deserialize<int>(response.Headers.GetValues("totalRecord").First(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
            }
            return totalrecord;
        }

    }
}
