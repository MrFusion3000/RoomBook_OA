using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

//using Microsoft.AspNetCore.Components.Authorization;
//using RoomBook_OA_UI.AuthProviders;

namespace RoomBook_OA_UI;
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");

        builder.Services
            .AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)})
            .AddMudServices();

        //builder.Services
        //    .AddMudServices();

        var host = builder.Build();

        await host.RunAsync();
    }
}