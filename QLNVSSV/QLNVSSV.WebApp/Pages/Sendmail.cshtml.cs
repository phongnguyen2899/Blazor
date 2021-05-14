using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLNVSSV.Models.Modes;
using QLNVSSV.WebApp.ApiIntergration;

namespace QLNVSSV.WebApp.Pages
{
    public class SendmailModel : PageModel
    {
        public List<Employee> listEmployee;

        public void OnGet()
        {
            listEmployee = GetData<Employee>.GetList("http://localhost:37919/api/Employee/GetEmployeeSendMail/1");
        }
    }
}
