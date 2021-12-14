using Application.Shared.DTO;
using Domain.Entities;
using Mapster;
using System.Reflection;

namespace Application;
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
            .PreserveReference(true);
        //If ignore ID here but leave ID property in DTO then ID = 00000000-0000-0000-0000-000000000000
        //.Ignore("ID")

        TypeAdapterConfig<Room, RoomDto>
            .NewConfig()
            .PreserveReference(true);

        TypeAdapterConfig<TimeSlot, TimeSlotDto>
            .NewConfig()
            .PreserveReference(true);

        TypeAdapterConfig<User, UserForAuthenticationDto>
            .NewConfig()
            .PreserveReference(true);

        TypeAdapterConfig<User, UserForRegistrationDto>
            .NewConfig()
            .PreserveReference(true);

        TypeAdapterConfig<User, UserForEditDto>
            .NewConfig()
            .PreserveReference(true);

        TypeAdapterConfig.GlobalSettings.Compile();
    }
}