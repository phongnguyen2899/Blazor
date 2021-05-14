using Microsoft.AspNetCore.Mvc.RazorPages;
using QLNVSSV.Models.Modes;
using QLNVSSV.Models.ViewModel;
using QLNVSSV.WebApp.ApiIntergration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNVSSV.WebApp.Pages
{
    public class ApprovalModel : PageModel
    {
        public List<Employee> employee { get; set; }
        public List<Positions> listPositions { get; set; }
        public List<Title> listTitle { get; set; }
        public void OnGet()
        {
            employee =ApiIntergration.GetData<Employee>.GetList("http://localhost:37919/api/Employee/GetEmployeeStatus/0");
            listPositions= ApiIntergration.GetData<Positions>.GetList("http://localhost:37919/api/Position/GetAll");
            listTitle= ApiIntergration.GetData<Title>.GetList("http://localhost:37919/api/Title/GetAll");
        }
        public async Task  OnPost(ApprovalFillterViewModel model)
        {
            employee = await ApiIntergration.GetData<Employee>.GetListPost("http://localhost:37919/api/Employee/GetbyfilterAproval", model);
            listTitle = ApiIntergration.GetData<Title>.GetList("http://localhost:37919/api/Title/GetAll");
            listPositions = ApiIntergration.GetData<Positions>.GetList("http://localhost:37919/api/Position/GetAll");
        }
        
    }
}
