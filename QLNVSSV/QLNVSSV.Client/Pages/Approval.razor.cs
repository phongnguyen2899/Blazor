using QLNVSSV.Client.Components;
using QLNVSSV.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using AntDesign;

namespace QLNVSSV.Client.Pages
{
    public partial class Approval
    {
        public bool loading { get; set; } = false;
        void toggle(bool value) => loading = value;
        private UpdateEdit Modal { get; set; }
        public int eID { get; set; }
        public List<QLNVSSV.Models.Modes.Employee> listEmployee { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            await GetData();
        }

        public async Task GetData()
        {
            toggle(true);
            listEmployee = await ApiIntergration.GetData<QLNVSSV.Models.Modes.Employee>.GetList("http://localhost:37919/api/Employee/GetEmployeeStatus/0");
            toggle(false);
        }
        public async Task Reload()
        {
           await GetData();
        }
        private ViewCVModal viewCVModal { get; set; }

       


        public async Task ReloadData(ApprovalFillterViewModel approvalFillterViewModel)
        {
            await GetData();
            if (approvalFillterViewModel.EmployeeName != null)
            {
                listEmployee = listEmployee.Where(x => x.EmployeeName.Contains("" + approvalFillterViewModel.EmployeeName + "")).ToList();
            }
            if (approvalFillterViewModel.Position > 0)
            {
                listEmployee = listEmployee.Where(x => x.PositionId == approvalFillterViewModel.Position).ToList();
            }
            if (approvalFillterViewModel.Title > 0)
            {
                listEmployee = listEmployee.Where(x => x.TitleId == approvalFillterViewModel.Title).ToList();
            }
        }



        public  async Task UpdateStatus(int employeeId,int status)
        {
            string url = $"http://localhost:37919/api/Employee/UpdateStatus/{employeeId}/{status}";
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var result =  response.Content.ReadAsStringAsync();
                }
            }

            await NoticeWithIcon(NotificationType.Success);
            await GetData();
        }

        private async Task NoticeWithIcon(NotificationType type)
        {
            await _notice.Open(new NotificationConfig()
            {
                Message = "Duyệt thành công",
                Description = "",
                NotificationType = type
            });
        }
    }
}
