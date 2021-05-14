using AntDesign;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using QLNVSSV.Client.ApiIntergration;
using QLNVSSV.Client.Components;
using QLNVSSV.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QLNVSSV.Client.Pages
{
    public partial class SendMail
    {
        public List<QLNVSSV.Models.Modes.Employee> listEmployee { get; set; } = new();
        private bool isCheckAll { get; set; } = false;
        private bool isSubCheck { get; set; }

        public MailModal mailModal { get; set; }

        protected override async Task OnInitializedAsync()
        {
            toggle(true);
            listEmployee =await GetData<QLNVSSV.Models.Modes.Employee>.GetList("http://localhost:37919/api/Employee/GetEmployeeSendMail/1");
            toggle(false);
        }
        public void CheckAll(ChangeEventArgs e)
        {
            isSubCheck =(bool)e.Value;
        }

        bool loading = false;

        void toggle(bool value) => loading = value;

        public List<int> listEmployeeId { get; set; } = new();
        public void CheckboxClicked(int id,object value)
        {
            if ((bool)value)
            {
                listEmployeeId.Add(id);
            }
            else
            {
                listEmployeeId.Remove(id);
            }


            foreach(var item in listEmployeeId)
            {
                Console.WriteLine(item);
                
            }
            Console.WriteLine("-----------");
        }
        public async  Task Send()
        {
            toggle(true);
            var url = "http://localhost:37919/api/MailContent/SendMail";
            var sendMailViewModel = new SendMailViewModel() { listId = listEmployeeId.ToArray() };
            var json = JsonConvert.SerializeObject(sendMailViewModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(url, data);
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync();
                }
            }
            toggle(false);
        }
        public async Task ChangeSolidariry(ChangeEventArgs arg,int employeeId)
        {
            
            var model = new ChangeSolidarityViewModel() { employeeId = employeeId, solidirity = Convert.ToInt32(arg.Value) };


            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsync("http://localhost:37919/api/Employee/ChangeSolidarity", data);
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync();
                }
            }
            await NoticeWithIcon(NotificationType.Success);
        }

        public async Task ChangeInterviewTime(ChangeEventArgs arg,int id)
        {
            var model = new ChangeInterviewTimeViewModel() { employeeId = id, interviewtime = Convert.ToDateTime(arg.Value) };


            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsync("http://localhost:37919/api/Employee/ChangeInterviewTime", data);
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync();
                }
            }
            await NoticeWithIcon(NotificationType.Success);
        }

        private async Task NoticeWithIcon(NotificationType type)
        {
            await _notice.Open(new NotificationConfig()
            {
                Message = "Cập nhật thành công",
                Description = "",
                NotificationType = type
            });
        }

    }
}
