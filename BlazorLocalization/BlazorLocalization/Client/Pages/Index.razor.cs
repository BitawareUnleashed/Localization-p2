using BlazorLocalization.Client.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorLocalization.Client.Pages
{
    public partial class Index
    {
        private string txt = string.Empty;

        [CascadingParameter]
        public MainLayout? Layout { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            await localizedMessageService.InitializeBackEndMessaging();
        }

        protected override async void OnParametersSet()
        {
            txt = await localizedMessageService.GetMessageAsync(Layout!.Message, Thread.CurrentThread.CurrentCulture);
            StateHasChanged();
            base.OnParametersSet();
        }
    }
}
