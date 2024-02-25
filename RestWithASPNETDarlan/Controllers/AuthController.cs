using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETDarlan.Business;
using RestWithASPNETDarlan.Data.VO;

namespace RestWithASPNETDarlan.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class AuthController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UserVO userVO)
        {
            if (userVO == null) return BadRequest("Invalid client request");

            var token = _loginBusiness.ValidateCredentials(userVO);
            if (token == null) return Unauthorized();

            return Ok(token);
        }

    }
}
