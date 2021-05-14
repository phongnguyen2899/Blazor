using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLNVSSV.DATA.Interfaces;
using QLNVSSV.Models.Modes;

namespace QLNVSSV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TitleController : BaseAPIController<Title>
    {
        public TitleController(IBaseRepository<Title> baseRepository):base(baseRepository)
        {

        }
    }
}
