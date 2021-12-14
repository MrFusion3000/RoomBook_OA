using Application.Shared.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.Logging;
using RoomBookApiClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http.Json;

namespace RoomBook_OA_UI.Pages;
public partial class Index
{
    private List<RoomDto> rooms = new();
    public readonly RoomClient roomClient = new();

    protected override async Task OnInitializedAsync()
    {
        NavigationManager.LocationChanged += HandleLocationChanged;

        try
        {
            await RefreshDb();

            bool hasElements = rooms.Any();
            if (!hasElements)
            {
                await InitRoom();
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"There was a problem; {ex.Message}");
        }
    }

    private async Task RefreshDb()
    {
        //Get current rooms
        rooms = await roomClient.GetAllRoomsAsync();
    }

    private async Task InitRoom()
    {
        var room = new RoomDto()
        {
            ID = Guid.NewGuid(),
            Name = "Init Room",
            Placement = 1,
            CreatedUTC = DateTime.UtcNow
        };

        await _http.PostAsJsonAsync("https://localhost:5001/api/v1/Room", room);
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