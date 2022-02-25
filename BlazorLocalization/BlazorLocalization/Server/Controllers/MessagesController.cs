using BlazorLocalization.Server.Data;
using BlazorLocalization.Server.HubSignalR;
using BlazorLocalization.Server.Resources;
using BlazorLocalization.Shared;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace BlazorLocalization.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private DataContext Datacontext { get; set; }

        private readonly ILogger<MessagesController> logger;
        private readonly UiSender uiSender;

        public MessagesController(ILogger<MessagesController> logger, DataContext dataContext, UiSender uiSender)
        {
            this.logger = logger;
            this.Datacontext = dataContext;
            this.uiSender = uiSender;
        }


        [HttpGet("{language}/{ID}")]
        public IActionResult Get(string language, string ID)
        {
            var culture = new CultureInfo(language);

            var t = Language.ResourceManager.GetString(ID, culture);

            return Ok(t);
        }
        //await Task.Delay(TimeSpan.FromSeconds(5));
        
        private async Task SendSimpleMessageAsync(string message)
        {
            this.uiSender.SendAsync(message);
        }
    }
}