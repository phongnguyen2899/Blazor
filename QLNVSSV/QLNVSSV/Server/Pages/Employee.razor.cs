
using QLNVSSV.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QLNVSSV.Client.Pages
{
    public partial class Employee
    {
        public MetaData MetaData { get; set; } = new();
        private List<QLNVSSV.Models.Modes.Employee> listEmployee { get; set; } = new();

        private PageParameters pageParameter = new PageParameters() { PageNumber = 1, pageSize = 3 };
        protected override async Task OnInitializedAsync()
        {
            await GetEmployee();
        }

        private async Task SelectedPage(int page)
        {
            pageParameter.PageNumber = page;
            await GetEmployee();
        }

        private async Task GetEmployee()
        {
            listEmployee = await ApiIntergration.GetData<QLNVSSV.Models.Modes.Employee>.GetList($"http://localhost:37919/api/Employee/GetPaging?PageNumber={pageParameter.PageNumber}&pageSize={pageParameter.pageSize}");
            MetaData = await ApiIntergration.GetDataFromHeader<MetaData>.GetData($"http://localhost:37919/api/Employee/GetPaging?PageNumber={pageParameter.PageNumber}&pageSize={pageParameter.pageSize}");
        }
    }
}
