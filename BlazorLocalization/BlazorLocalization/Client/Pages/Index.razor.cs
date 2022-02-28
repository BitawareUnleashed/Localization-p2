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
        public MainLayout Layout { get; set; }

        protected override void OnInitialized()
        {
            Layout.MessageReceived += Layout_MessageReceived;
            base.OnInitialized();
        }

        private async void Layout_MessageReceived(object? sender, string e)
        {
            var culture = Thread.CurrentThread.CurrentCulture;
            var s = await Http.GetAsync(@$"Messages/{ culture.TwoLetterISOLanguageName}/{e}");
            if (s != null)
            {
                txt = e.ToString() +" - "+ await s.Content.ReadAsStringAsync();
            }
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            var s = await Http.GetAsync(@$"Messages");
        }
    }
}
