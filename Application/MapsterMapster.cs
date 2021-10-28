using Application.Shared.DTO;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class MapsterMapster
    {
        public static void MapsterSetter()
            {
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetEntryAssembly());

            TypeAdapterConfig.GlobalSettings.RequireExplicitMapping = false;

            TypeAdapterConfig<Room, RoomDto>
                .NewConfig()
                .PreserveReference(true);

            var config = TypeAdapterConfig<TimeSlot, TimeSlotDto>
                .NewConfig()
                .TwoWays()
                .PreserveReference(true);
            
            TypeAdapterConfig<Booker, BookerDto>
                .NewConfig()
            .PreserveReference(true);

            TypeAdapterConfig<Booker, BookerDtoIn>
                .NewConfig()
                .PreserveReference(true)
                //If ignore ID here but leave ID property in DTO then ID = 00000000-0000-0000-0000-000000000000
                //.Ignore("ID")
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.CreatedUTC, src => src.CreatedUTC);

            TypeAdapterConfig<Room, RoomDto>
                .NewConfig()
                .PreserveReference(true);
                    //.Map(dest => dest.ID, src => src.ID)
                    //.Map(dest => dest.Name, src => src.Name)
                    //.Map(dest => dest.TimeSlots, src => src.TimeSlots);
            //.ignore


        TypeAdapterConfig<TimeSlot, TimeSlotDto>
            .NewConfig()
            .PreserveReference(true)
            .Map(dest => dest.ID, src => src.ID)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.UpdatedUTC, src => src.UpdatedUTC)
            .Map(dest => dest.Booker.Name, src => src.Booker.Name);
            
        TypeAdapterConfig.GlobalSettings.Compile();
        }

    }
}
