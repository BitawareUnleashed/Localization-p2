using BlazorLocalization.Server.Data;
using BlazorLocalization.Server.Resources;
using BlazorLocalization.Shared;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace BlazorLocalization.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuitarController : ControllerBase
    {
        private DataContext Datacontext { get; set; }

        private readonly ILogger<GuitarController> logger;

        public GuitarController(ILogger<GuitarController> logger, DataContext dataContext)
        {
            this.logger = logger;
            this.Datacontext = dataContext;
        }

        [HttpGet]
        public IEnumerable<Guitar> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Guitar
            {

            })
            .ToArray();
        }

        [HttpGet("{language}")]
        public IActionResult Get(string language)
        {
            var culture = new CultureInfo(language);

            var t = Language.ResourceManager.GetString("Temp", culture);

            return Ok(t);
        }
    }
}