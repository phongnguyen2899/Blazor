using QLNVSSV.DATA.Interfaces;
using QLNVSSV.Models.Common;
using QLNVSSV.Models.Modes;
using QLNVSSV.ViewModels.Common;
using System.Linq;

namespace QLNVSSV.DATA.Repository
{
    public class MailContentRepository:BaseRepository<MailContent>,IMailContentRepository
    {

        private readonly IEmployeeRepository _employeeRepository;
        public MailContentRepository(IEmployeeRepository employeeRepository,IDatabaseContext<MailContent> databaseContext):base(databaseContext)
        {
            _employeeRepository = employeeRepository;
        }

        public MailContent GetMailForemployee(int title)
        {
            int mailType=GetMailTypeByTitle(title);
            var data = base._databaseContext.Get("Proc_GetMailContentByType @type ", new object[] { mailType });
            return data.FirstOrDefault();
        }

        public ServiceResponse Sendmail(int[] listEmployeeId)
        {
            for(int i = 0; i < listEmployeeId.Length; i++)
            {
                var employee= _employeeRepository.GetById(listEmployeeId[i]);
                var mailType = GetMailTypeByTitle(employee.TitleId);
                var mail= base._databaseContext.Get("Proc_GetMailContentByType @type ", new object[] { mailType }).FirstOrDefault();

                string mailContent = $"Chào {employee.EmployeeName}";
                mailContent += mail.Title;
                mailContent += $"Thời gian phỏng vấn dự kiến bắt đầu từ {employee.InterviewTime}";
                Mailhelper.SendMail(employee.Email, mail.Title,mailContent);
            }
            var serviceResponse = new ServiceResponse();
            serviceResponse.Success = true;
            serviceResponse.Msg.Add("Thành công");
            return serviceResponse;
        }

        public int GetMailTypeByTitle(int title)
        {
            int mailType = 0;
            switch (title)
            {
                case 1:
                    mailType = 0;
                    break;
                case 2:
                    mailType = 2;
                    break;
                case 3:
                    mailType = 4;
                    break;
            }
            return mailType;
        }

    }
}
