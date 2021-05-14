using QLNVSSV.Models.Enum;
using System;

namespace QLNVSSV.Models.Modes
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Presenter { get; set; }
        public string CV { get; set; }
        public EStatus Status { get; set; }
        public string Note { get; set; }
        public DateTime InterviewTime { get; set; }
        public int TestScores { get; set;}
        public bool isApply { get; set; }
        public string Failure { get; set; }
        public string InterviewAddress { get; set; }
        public string PositionName { get; set; }
        public string TitleName { get; set; }
        public string PresenterName { get; set; }
        public int PositionId { get; set; }
        public int TitleId { get; set; }
        public int Solidarity { get; set; }

        public int InterviewerId { get; set; }

        public string InterviewName { get; set; }
    }
}
