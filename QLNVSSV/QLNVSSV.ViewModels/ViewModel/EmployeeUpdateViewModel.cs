using System;
using System.Collections.Generic;
using System.Text;

namespace QLNVSSV.Models.ViewModel
{
    public class EmployeeUpdateViewModel
    {
            public int id { get; set; }
            public string name { get; set; }
            public string address { get; set; }
            public string email { get; set; }
            
            public int positionid { get; set; }
            public int titleid { get; set; }
    }
}
