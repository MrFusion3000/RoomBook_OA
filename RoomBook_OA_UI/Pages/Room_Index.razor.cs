using Application.Shared.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.Logging;
using RoomBook_OA_UI.Helpers.Extensions;
using RoomBookApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

//inject NavigationManager NavigationManager;
//inject ILogger<Room_Index> Logger;
//inject HttpClient _http;

namespace RoomBook_OA_UI.Pages;
public partial class Room_Index : ComponentBase
{
    [Parameter] public Guid InstaBookerGuid { get; set; } = Guid.Parse("99999999-9999-9999-9999-999999999999");

    public RoomDto room = new();
    private List<TimeSlotDto> allTimeSlotsOfToday;
    private List<TimeSlotDto> currentTimeSlots;
    readonly RoomClient roomClient = new();

    [Parameter] public Guid ThisRoomId { get; set; }
    [Parameter] public int? HasItems { get; set; }
    [Parameter] public TimeSlotDto FirstVacantSlot { get; set; }
    [Parameter] public int AnyVacantSlot { get; set; }


    //private string _searchString = "";
    [Parameter] public TimeSlotDto SelectedItem { get; set; }
    //private HashSet<TimeSlotDto> _selectedItems = new HashSet<TimeSlotDto>();

    public DateTime dtToday = DateTime.UtcNow;

    //private bool FilterFunc(ITimeSlot slot)
    //{
    //    if (string.IsNullOrWhiteSpace(_searchString))
    //        return true;

    //    if (slot.Title.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
    //        return true;

    //    return false;
    //}

    protected override async Task OnInitializedAsync()
    {
        // 1. Check if room exists
        // 2.a. if room exists check for timeslots
        //      2.a.1 if timeslots exists read those to list
        //      2.a.2 if timeslots doesn't exist create daily schedule
        // 2.b if room doesn't exists create room

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
        //var showRoom = await _http.GetFromJsonAsync<RoomDto>("https://localhost:44315/api/v1/Room/GetByIdAndDateTime/" + ThisRoomId + "," + _dtToday);

        room = await roomClient.GetRoomByIdAndDateAsync(ThisRoomId, dtToday);

        if (!room.TimeSlots.Any()) await InitDailySchedule();

        allTimeSlotsOfToday = room.TimeSlots;
        currentTimeSlots = allTimeSlotsOfToday.GetAllCurrentTimeSlots(dtToday);
        //HasItems = currentTimeSlots.Count;
        FirstVacantSlot = allTimeSlotsOfToday.GetFirstVacant(dtToday);
        //AnyVacantSlot = allTimeSlotsOfToday.Count(f => f.IsVacant);

        StateHasChanged();
    }

    private async Task UpdateTimeSlot(TimeSlotDto vacantSlot, string title, Guid bookerId)
    {
        var updateTimeSlot = new TimeSlotDto
        {
            ID = (Guid)vacantSlot.ID,
            TimeSlotStart = vacantSlot.TimeSlotStart,
            TimeSlotEnd = vacantSlot.TimeSlotEnd,
            IsVacant = false,
            CreatedUTC = vacantSlot.CreatedUTC,
            Title = title,
            UpdatedUTC = DateTime.UtcNow,
            BookerId = bookerId,
            RoomId = vacantSlot.RoomId
        };
        await _http.PutAsJsonAsync($"https://localhost:44315/api/v1/TimeSlot/Update?id={updateTimeSlot.ID}", updateTimeSlot);

        await RefreshDb();
    }

    // Init empty room
    private async Task InitRoom()
    {
        var room = new Room
        {
            ID = ThisRoomId,
            Name = "Init Room",
            Placement = 1,
            CreatedUTC = dtToday
        };

        await _http.PostAsJsonAsync("https://localhost:44315/api/v1/Room", room);
    }

    private async Task InitBooker()
    {
        var booker = new Booker()
        {
            ID = Guid.Empty,
            Name = "Joe Dull",
            CreatedUTC = DateTime.Now
        };
        await _http.PostAsJsonAsync("https://localhost:44315/api/v1/Booker", booker);
    }

    private async Task InitDailySchedule()
    {
        TimeSpan duration = new(0, 0, 15, 0);
        DateTime initDate = new(dtToday.Year, dtToday.Month, dtToday.Day, 6, 0, 0);

        for (var i = 0; i < 60; i++)
        {
            var timeSlot = new TimeSlot
            {
                ID = Guid.NewGuid(),
                TimeSlotStart = initDate,
                TimeSlotEnd = initDate.Add(duration),
                Title = "Vacant",
                IsVacant = true,
                CreatedUTC = dtToday,
                RoomId = ThisRoomId,
                BookerId = Guid.Empty,
            };

            await _http.PostAsJsonAsync("https://localhost:44315/api/v1/TimeSlot", timeSlot);

            initDate = initDate.Add(duration);
        }
    }

    private void GotoRoom(Guid roomId)
    {
        string navUri = "/Room_Index/" + roomId;
        NavigationManager.NavigateTo(navUri);
    }

    private void NavigateToRoomsPage(string chosenPage)
    {
        NavigationManager.NavigateTo(chosenPage);

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