using QLNVSSV.Models.Modes;
using QLNVSSV.ViewModels.Common;

namespace QLNVSSV.DATA.Interfaces
{
    public interface IMailContentRepository:IBaseRepository<MailContent>
    {
        MailContent GetMailForemployee(int title);

        ServiceResponse Sendmail(int[] listEmployeeId);
    }
}
