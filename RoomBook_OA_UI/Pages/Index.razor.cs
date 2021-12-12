using Application.Shared.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.Logging;
using RoomBookApiClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RoomBook_OA_UI.Pages;
public partial class Index
{
    private List<RoomDto> rooms = new();
    public readonly RoomClient roomClient = new();

    protected override async Task OnInitializedAsync()
    {
        NavigationManager.LocationChanged += HandleLocationChanged;

        //AuthConfig config = AuthConfig.ReadJsonFromFile("appsettings.json");

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