using QLNVSSV.BUS.Interfaces;
using QLNVSSV.DATA.Interfaces;
using QLNVSSV.Models.Modes;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLNVSSV.BUS.Service
{
    public class EmployeeService:BaseService<Employee>,IEmployeeService
    {
        public EmployeeService(IEmployeeRepository employeeRepository):base(employeeRepository)
        {

        }
    }
}
