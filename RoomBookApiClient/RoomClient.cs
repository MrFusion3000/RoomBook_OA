using Application.Shared.DTO;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookApiClient
{
    public class RoomClient
        :BaseClient
    {
        private Url GetRoomClient() => base.GetClient().AppendPathSegment("Room");

        public async Task<RoomDto> GetRoomByIdAndDateTimeAsync(Guid id, DateTime queryDateTime)
        {
            //return await GetRoomClient().AppendPathSegment("GetByIdAndDateTime").SetQueryParams(new { id, queryDateTime }).GetJsonAsync<RoomDto>();
            return await GetRoomClient().AppendPathSegment("GetByIdAndDateTime").AppendPathSegment(id).AppendPathSegment(queryDateTime).GetJsonAsync<RoomDto>();

        }
    }
}
