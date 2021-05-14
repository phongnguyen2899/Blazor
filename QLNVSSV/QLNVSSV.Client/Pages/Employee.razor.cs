using AntDesign;
using Microsoft.AspNetCore.Components;
using QLNVSSV.Client.Components;
using QLNVSSV.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QLNVSSV.Client.Pages
{
    public partial class Employee
    {
        public bool loading { get; set; } = false;
        void toggle(bool value) => loading = value;
        private UpdateEdit Modal { get; set; }

        public MetaData MetaData { get; set; } = new();
        private List<QLNVSSV.Models.Modes.Employee> listEmployee { get; set; } = new();

        private PageParameters pageParameter = new PageParameters() { PageNumber = 1,pageSize = 5};

        protected override async Task OnInitializedAsync()
        {
            await GetEmployee();
        }

        private async Task SelectedPage(int page)
        {
             pageParameter.PageNumber= page;
            await GetEmployee();
        }

        private async Task GetEmployee()
        {
            toggle(true);
            listEmployee = await ApiIntergration.GetData<QLNVSSV.Models.Modes.Employee>.GetList($"http://localhost:37919/api/Employee/GetPaging1?PageNumber={pageParameter.PageNumber}&pageSize={pageParameter.pageSize}");
            MetaData = await ApiIntergration.GetDataFromHeader<MetaData>.GetData($"http://localhost:37919/api/Employee/GetPaging1?PageNumber={pageParameter.PageNumber}&pageSize={pageParameter.pageSize}");
            toggle(false);
        }

        private void ModalOpen()
        {
            Modal.type = 1;
            Modal.Open();
        }

        private void ShowInfor(int id)
        {
            Modal.Show(id);
        }
        private async Task Delete(int Id)
        {
            var url = $"http://localhost:37919/api/Employee/{Id}";
             await ApiIntergration.GetData<int>.Delete(url,Id);
            await GetEmployee();
            await NoticeWithIcon(NotificationType.Success);
        }

        private async Task NoticeWithIcon(NotificationType type)
        {
            await _notice.Open(new NotificationConfig()
            {
                Message = "Xóa thành công!",
                Description = "",
                NotificationType = type
            });
        }
    }
}
