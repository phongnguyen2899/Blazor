using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLNVSSV.Models.Modes;
using QLNVSSV.Models.ViewModel;
using QLNVSSV.WebApp.ApiIntergration;

namespace QLNVSSV.WebApp.Pages
{
    public class ScheduleModel : PageModel
    {
        public List<Positions> listPositions { get; set; }
        public List<Title> listTitle { get; set; }
        public List<Employee> listEmployee;
        public List<Employee> listInterviewer;
        public void OnGet()
        {
            //lay ra data da duyet cv
            listEmployee = GetData<Employee>.GetList("http://localhost:37919/api/Employee/GetEmployeeSendMail/1");
            listInterviewer = ApiIntergration.GetData<Employee>.GetList("http://localhost:37919/api/Employee/GetEmployeeStatus/13");

            listPositions = ApiIntergration.GetData<Positions>.GetList("http://localhost:37919/api/Position/GetAll");
            listTitle = ApiIntergration.GetData<Title>.GetList("http://localhost:37919/api/Title/GetAll");
        }
        public void OnPost(ScheduleFilterViewModel model)
        {
            listEmployee = GetData<Employee>.GetList("http://localhost:37919/api/Employee/GetEmployeeSendMail/1");
            listInterviewer = ApiIntergration.GetData<Employee>.GetList("http://localhost:37919/api/Employee/GetEmployeeStatus/13");

            listPositions = ApiIntergration.GetData<Positions>.GetList("http://localhost:37919/api/Position/GetAll");
            listTitle = ApiIntergration.GetData<Title>.GetList("http://localhost:37919/api/Title/GetAll");

            if (model.EmployeeName != null)
            {
                listEmployee = listEmployee.Where(x => x.EmployeeName.Contains("" + model.EmployeeName + "")).ToList();
            }
            if (model.Position != 0)
            {
                listEmployee = listEmployee.Where(x => x.PositionId == model.Position).ToList();
            }

            if (model.Title != 0)
            {
                listEmployee = listEmployee.Where(x => x.TitleId == model.Title).ToList();
            }
            if (model.InterviewAddress != null)
            {
                listEmployee = listEmployee.Where(x => x.InterviewAddress == model.InterviewAddress).ToList();
            }
            if (model.Start != DateTime.MinValue)
            {
                listEmployee = listEmployee.Where(x => x.InterviewTime > model.Start).ToList();
            }
            if (model.End != DateTime.MinValue)
            {
                listEmployee = listEmployee.Where(x => x.InterviewTime < model.End).ToList();
            }
        }
    }
}
