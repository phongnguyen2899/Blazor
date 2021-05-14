using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QLNVSSV.Client.Model;
using QLNVSSV.DATA.Interfaces;
using System.Threading.Tasks;

namespace QLNVSSV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseAPIController<T> : ControllerBase
    {
        const int pagesize = 3;

        protected readonly IBaseRepository<T> _baseRepository;
        public BaseAPIController(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _baseRepository.GetById(id);

            return Ok(data);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _baseRepository.Get();


            return Ok(data);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public IActionResult Create([FromForm] IFormFile mill)
        {
            return Ok("aaa");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _baseRepository.Delete(id);

            return Ok(result);
        }

        [HttpPut]
         public  IActionResult Update([FromBody]T Entity)
         {

            var serviceResponse= _baseRepository.Update(Entity);

            return Ok(serviceResponse);
         }

        
        [HttpGet("GetCount")]
        public IActionResult GetCountRecord()
        {
            var serviceResponse = _baseRepository.GetCountRecord();

            return Ok(serviceResponse);
        }
        
        [HttpGet("Page/{pageindex}")]
        public IActionResult GetPaging(int pageindex)
        {
            var data = _baseRepository.GetPaging(pageindex,pagesize);

            return Ok(data);
        }

        [HttpGet("GetPaging")]
        public virtual  IActionResult GetPage([FromQuery]PageParameters parameters)
        {
            var data = _baseRepository.GetPaged(parameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(data.MetaData));
            return Ok(data);
        }
    }
}
