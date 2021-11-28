using Application.Shared.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.Logging;
using RoomBook_OA_UI.Helpers.Extensions;
using RoomBookApiClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RoomBook_OA_UI.Pages;
public partial class Index
{
    private List<RoomDto> rooms = new();
    public readonly RoomClient roomClient = new();

    //public string path = "";
    //public string[] fileNames;

    //public AuthConfig config = AuthConfig.ReadJsonFromFile("appsettings.json");

    protected override async Task OnInitializedAsync()
    {
        NavigationManager.LocationChanged += HandleLocationChanged;

        //path = Directory.GetCurrentDirectory();
        //fileNames = Directory.GetFiles(path);

        try
        {
            await RefreshDb();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"There was a problem; {ex.Message}");
        }
    }

    private async Task RefreshDb()
    {
        //Get current rooms
        //rooms = await _http.GetFromJsonAsync<List<RoomDto>>("https://localhost:44315/api/v1/Room/");
        rooms = await roomClient.GetAllRoomsAsync();
    }

    private void GotoRoom(Guid roomId)
    {
        string navUri = "/Room_Index/" + roomId;
        NavigationManager.NavigateTo(navUri);
    }

    private void HandleLocationChanged(object sender, LocationChangedEventArgs e)
    {
        Logger.LogInformation("URL of new location: {Location}", e.Location);
    }

    public void Dispose()
    {
        NavigationManager.LocationChanged -= HandleLocationChanged;
    }
}