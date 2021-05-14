using Microsoft.AspNetCore.Mvc;
using QLNVSSV.DATA.Interfaces;
using QLNVSSV.Models.Modes;

namespace QLNVSSV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IBaseRepository<Positions> _baseRepository;

        public PositionController(IBaseRepository<Positions> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _baseRepository.Get();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _baseRepository.GetById(id);
            return Ok(data);
        }
    }
}
