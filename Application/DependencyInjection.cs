using System.Reflection;
using Application.Shared.DTO;
using Domain.Entities;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            //MapsterMapster.MapsterSetter();

            //services.AddMediatR(Assembly.GetExecutingAssembly());

            //TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetEntryAssembly());
            //TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
            //TypeAdapterConfig<Room, RoomDto>.NewConfig()
            //    //.Map(dest => dest, src => src);
            //    .Map(dest => dest.Id, src => src.ID)
            //    .Map(dest => dest.Name, src => src.Name);
                //.Map(dest => dest.TimeSlots, src => src.TimeSlots);
                //.Map(dest => dest.TimeSlots.Booker, src => src.TimeSlots.b);
        }

        
    }


}
