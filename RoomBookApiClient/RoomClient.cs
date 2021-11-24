using Application.Shared.DTO;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomBookApiClient;
public class RoomClient : BaseClient
{
    private Url GetRoomClient() => GetClient().AppendPathSegment("Room");

    public async Task<RoomDto> GetRoomByIdAndDateAsync(Guid id, DateTime queryDate)
    {
        //return await GetRoomClient().AppendPathSegment("GetByIdAndDateTime").SetQueryParams(new { id, queryDatee }).GetJsonAsync<RoomDto>();
        return await GetRoomClient().AppendPathSegment("GetByIdAndDateTime").AppendPathSegment(id).AppendPathSegment(queryDate).GetJsonAsync<RoomDto>();
    }

    public async Task<List<RoomDto>> GetAllRoomsAsync()
    {
        return await GetRoomClient().GetJsonAsync<List<RoomDto>>();
    }
}