using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorLocalization.Client.Extensions;

public static class CultureExtension
{
    public async static Task SetDefaultCulture(this WebAssemblyHost host)
    {
        var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
        var result = await jsInterop.InvokeAsync<string>("blazorLanguage.get");
        CultureInfo culture;
        if (result != null)
            culture = new CultureInfo(result);
        else
            culture = new CultureInfo("en");
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
    }
}

