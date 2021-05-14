using Newtonsoft.Json;
using QLNVSSV.Client.ApiIntergration;
using QLNVSSV.Client.Model;
using QLNVSSV.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;
namespace QLNVSSV.Client.Pages
{
    public partial class Schedule
    {
        public List<QLNVSSV.Models.Modes.Employee> listEmployee { get; set; } = new();
        public List<QLNVSSV.Models.Modes.Employee> listInterviewer { get; set; } = new();

        public string ModalClass { get; set; }

        public MetaData MetaData { get; set; } = new();

        private PageParameters pageParameter = new PageParameters() { PageNumber = 1, pageSize = 2};

        public string DissplayModal { get; set; } = "none";


        public void Open()
        {
            DissplayModal = "block;";
            ModalClass = "show";
            StateHasChanged();
        }
        public void Close()
        {
            DissplayModal = "none";
            ModalClass = "";
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
           await GetData();
        }

        private async Task SelectedPage(int page)
        {
            pageParameter.PageNumber = page;
            await GetData();
        }

        private async Task GetData()
        {

            MetaData = await GetHeader();

            listEmployee = await GetEmployee($"http://localhost:37919/api/Employee/GetEmployeeStatusAproval");

            listInterviewer = await ApiIntergration.GetData<QLNVSSV.Models.Modes.Employee>.GetList("http://localhost:37919/api/Employee/GetEmployeeStatus/13");
           
        }

        private async Task<MetaData> GetHeader()
        {
            var instance = new MetaData();
            var json = JsonConvert.SerializeObject(pageParameter);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync("http://localhost:37919/api/Employee/GetEmployeeStatusAproval",data);
                
                if (response.IsSuccessStatusCode)
                {

                    instance = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
            }
            return instance;
        }

        private async Task<List<QLNVSSV.Models.Modes.Employee>>  GetEmployee(string url)
        {
            var listdata = new List<QLNVSSV.Models.Modes.Employee>();
            var json = JsonConvert.SerializeObject(pageParameter);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(url, data);
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync();

                    listdata = (List<QLNVSSV.Models.Modes.Employee>)JsonConvert.DeserializeObject(result.Result, typeof(List<QLNVSSV.Models.Modes.Employee>));
                }
            }
            return listdata;
        }


        public QLNVSSV.Models.Modes.Employee employee { get; set; } = new();
        public async Task Show(int id)
        {
            var url = $"http://localhost:37919/api/Employee/{id}'";

            employee = await ApiIntergration.GetData<QLNVSSV.Models.Modes.Employee>.GetById($"http://localhost:37919/api/Employee/{id}");
            Open();
        }

        public async Task Imsposed()
        {
            string url = "http://localhost:37919/api/Employee/UpdateSchedule";
            UpdateScheduleViewModel model = new UpdateScheduleViewModel()
            {
                EmployeeId = employee.EmployeeId,
                InterviewerId = employee.InterviewerId,
                InterviewAddress = employee.InterviewAddress,
                InterviewTime = employee.InterviewTime
            };

           await ApiIntergration.GetData<UpdateScheduleViewModel>.Put(url,model);
            Close();
        }

        public async Task LoadDataCalBack(PageParameters p)
        {
            pageParameter = p;
            pageParameter.pageSize = 2;
            pageParameter.PageNumber = 1;
           await GetData();
        }
    }
}
