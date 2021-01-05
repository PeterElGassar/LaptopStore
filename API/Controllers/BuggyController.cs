using API.Errors;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFound()
        {
            var thing = _context.Products.Find(666);

            if (thing == null)
                return NotFound( new ApiResponse(404));

            return Ok();

        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(666);

            var returnThing = thing.ToString();
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest( new ApiResponse(400));

        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }

    }
}