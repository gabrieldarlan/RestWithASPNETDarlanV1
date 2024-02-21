using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETDarlan.Model;
using RestWithASPNETDarlan.Business;
using RestWithASPNETDarlan.Data.VO;

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
        public IActionResult Get()
        {

            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
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
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            return Ok(_personBusiness.Create(person));
            
        }

        [HttpPut]
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
