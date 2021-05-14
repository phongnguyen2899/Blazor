using QLNVSSV.Client.Model;
using QLNVSSV.DATA.Paging;
using QLNVSSV.Models.Modes;
using QLNVSSV.Models.ViewModel;
using QLNVSSV.ViewModels.Common;
using System;
using System.Collections.Generic;

namespace QLNVSSV.DATA.Interfaces
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
        IEnumerable<Employee> GetEmployeebyStatus(int status);

        ServiceResponse UpdateStatusEmployee(int employeeId, int status);

        public IEnumerable<Employee> GetbyfilterAproval(ApprovalFillterViewModel approvalFillterViewModel);

        IEnumerable<Employee> GetEmployeeSendMail(int status);

        ServiceResponse UpdateSolidarity(int employeeId, int solidarity,DateTime interviewtime);

        ServiceResponse ChangeSolidarity(int employeeId, int solidarity);

        ServiceResponse ChangeInterviewTime(int employeeId, DateTime interviewtime);

        ServiceResponse UpdateSchedule(UpdateScheduleViewModel updateScheduleViewModel);

        PagedList<Employee> GetPaged_Status(int status, PageParameters parameters);
    }
}
