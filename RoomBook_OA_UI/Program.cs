using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RoomBook_OA_UI.Helpers;
using RoomBook_OA_UI.Services;
using MudBlazor.Services;


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
            //.AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)})
            .AddScoped<IAccountService, AccountService>()
            .AddScoped<IAlertService, AlertService>()
            .AddScoped<IHttpService, HttpService>()
            .AddScoped<ILocalStorageService, LocalStorageService>()
            .AddMudServices();

        // configure http client
        builder.Services.AddScoped(x => {
            var apiUrl = new Uri(builder.Configuration["apiUrl"]);

            // use fake backend if "fakeBackend" is "true" in appsettings.json
            if (builder.Configuration["fakeBackend"] == "true")
            {
                var fakeBackendHandler = new FakeBackendHandler(x.GetService<ILocalStorageService>());
                return new HttpClient(fakeBackendHandler) { BaseAddress = apiUrl };
            }

            return new HttpClient() { BaseAddress = apiUrl };
        });

        var host = builder.Build();

        var accountService = host.Services.GetRequiredService<IAccountService>();
        await accountService.Initialize();

        await host.RunAsync();
    }
}