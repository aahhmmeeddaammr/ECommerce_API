using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.API.Errors;

namespace Talabat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {

        [HttpGet("notfound")]
        public ActionResult NotFoundRequest()
        {
            return NotFound(new APIResponse(404));
        }
        [HttpGet("servererror")]
        public ActionResult ServerErrorRequest()
        {
         
                int x = 0;
                int y = 1;
                int z = y / x;
            
            return Ok();
        }
        [HttpGet("badrequest")]
        public ActionResult BadRequestResponse() { 
            return BadRequest();
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult BadRequestResponse(int id)
        {
            return Ok();
        }
    }
}
