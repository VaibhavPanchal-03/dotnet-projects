using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private  readonly TestService _testService;

        public TestController(ILogger<TestController> logger, TestService testService)
        {
            _logger = logger;
            _testService = testService;
        }

        //To add a model

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult addTest([FromBody] TestModel model)
        {
            _logger.LogInformation("Logger information called!");
            return Ok(_testService.ExecuteTest(model));
        }

        //fetch all models

        [HttpGet]
        [Produces("application/json")]
        public List<TestModel> getTests()
        {
            return _testService.GetTests();
        }

        //fetch specific id

        [HttpGet("{id}")]
        [Produces("application/json")]
        public TestModel getTestById([FromRoute(Name = "id")] string id)
        {
            return _testService.GetModelById(id);
        }

        //update specific property

        [HttpPatch("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public TestModel updateNameById([FromRoute] string id, [FromBody] string name) 
        {
            return _testService.updateNameById(id, name);
        }

        //delete a specific model
        [HttpDelete("{id}")]
        [Produces("application/json")]
        public List<TestModel> deleteById([FromRoute] string id)
        {
            return _testService.deleteById(id);
        }

        //throw exception on purpose
        [HttpGet("exception")]
        [Produces("application/json")]
        public void throwException()
        {
            throw new ArgumentNullException();
        }
    }
}
