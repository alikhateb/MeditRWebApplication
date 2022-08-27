namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly IStringLocalizer<LanguagesController> localizer;
        public LanguagesController(IStringLocalizer<LanguagesController> localizer)
        {
            this.localizer = localizer;
        }

        [HttpGet]
        public IActionResult Get()
        {
            string username = "ali";
            return Ok(localizer["hello", username].Value);
        }
    }
}
