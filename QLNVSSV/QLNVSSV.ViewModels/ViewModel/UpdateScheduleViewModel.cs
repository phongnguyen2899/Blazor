using System;
using System.Collections.Generic;
using System.Text;

namespace QLNVSSV.Models.ViewModel
{
    public class UpdateScheduleViewModel
    {
        public int InterviewerId { get; set; }
        public DateTime? InterviewTime { get; set; }
        public int? EmployeeId { get; set; }
        public string InterviewAddress { get; set; }
    }
}
