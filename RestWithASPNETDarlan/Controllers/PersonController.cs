using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETDarlan.Business;
using RestWithASPNETDarlan.Data.VO;
using RestWithASPNETDarlan.Hypermedias.Filters;

namespace RestWithASPNETDarlan.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {

            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {

            PersonVO person = _personBusiness.FindById(id);
            if (person==null)
            {
                return NotFound();
            }
            return base.Ok(person);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            return Ok(_personBusiness.Create(person));
            
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            return Ok(_personBusiness.Update(person));

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {

            _personBusiness.Delete(id);
          
            return base.NoContent();
        }

    }
}
