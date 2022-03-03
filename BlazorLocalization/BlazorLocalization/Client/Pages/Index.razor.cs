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
            _ = await http.GetAsync(@$"Messages");
        }

        protected override async void OnParametersSet()
        {
            var culture = Thread.CurrentThread.CurrentCulture;
            var s = await http.GetAsync(@$"Messages/{ culture.TwoLetterISOLanguageName}/{Layout!.Message}");
            if (s != null)
            {
                if (Layout.Message.ToString().Length > 0)
                {
                    txt = Layout.Message.ToString() + " - " + await s.Content.ReadAsStringAsync();
                }
            }
            StateHasChanged();
            base.OnParametersSet();
        }
    }
}
