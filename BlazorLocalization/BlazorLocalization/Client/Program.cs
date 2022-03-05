using BlazorLocalization.Client;
using BlazorLocalization.Client.Extensions;
using BlazorLocalization.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<LocalizedMessageService>();

builder.Services.AddLocalization();

var host=builder.Build();

await host.SetDefaultCulture();

await host.RunAsync();
