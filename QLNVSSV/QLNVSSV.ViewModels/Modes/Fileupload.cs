using Microsoft.AspNetCore.Http;

namespace QLNVSSV.Models.Modes
{
    public class Fileupload
    {
        public  IFormFile filecv { get; set; }
        public string fileNamelb { get; set; }
    }
}
