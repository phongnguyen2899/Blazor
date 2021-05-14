using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNVSSV.DATA.Interfaces;
using System.IO;

namespace QLNVSSV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IWebHostEnvironment _hostingEnvironment;

        private IEmployeeRepository _employeeRepository;
        public FileController(IWebHostEnvironment environment,IEmployeeRepository employeeRepository)
        {
            _hostingEnvironment = environment;
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public JsonResult Upload([FromForm]IFormFile filecv,string fileNamelb)
        {
            if (filecv != null)
            {
                //Get path
                string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Image");
                string filePath = Path.Combine(uploads, filecv.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    filecv.CopyTo(fileStream);
                }

                return new JsonResult(
                        new
                        {
                            mes = "success"
                        }
                    );
            }

            return new JsonResult(
                        new
                        {
                            mes = "err"
                        }
                    );
        }

        public void Deletefile(string filecv)
        {
            string fileDirectory = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot/Image/");

            string webRootPath = _hostingEnvironment.WebRootPath;

            var fileName = "";
            fileName = filecv;
            var fullPath = webRootPath + "/Image/" + filecv;

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
        }


    }
}
