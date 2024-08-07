using API.Controllers.Errors;
using Infrustructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly ILogger<BuggyController> _logger;
        public StoreContext Context { get; }

        public BuggyController(StoreContext context, ILogger<BuggyController> logger)
        {
            Context = context;
            _logger = logger;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFound(){
            var things = Context.Products.Find(42);
            if(things ==null){
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }
        [HttpGet("servererror")]
        public ActionResult GetServerError(){
            var things = Context.Products.Find(42);
            things.ToString();
            return Ok();
        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest(){
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFound(int id){
            return Ok();
        }
    }
}