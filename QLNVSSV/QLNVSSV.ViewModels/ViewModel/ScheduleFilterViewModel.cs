using System;
using System.Collections.Generic;
using System.Text;

namespace QLNVSSV.Models.ViewModel
{
    public  class ScheduleFilterViewModel
    {
        public string InterviewAddress { get; set; }
          public DateTime End { get; set; }
          public DateTime Start { get; set; }
           public int Soliratity { get; set; }
           public int Title { get; set; }
           public int Position { get; set; }
            public string EmployeeName { get; set; }
    }
}
