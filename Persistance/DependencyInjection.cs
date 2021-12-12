using Application;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Persistance.Repositories.Bookers;
using Persistance.Repositories.Rooms;
using Persistance.Repositories.TimeSlots;

namespace Persistance;
public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        //***To Use MediatR in the active layer only
        //services.AddMediatR(Assembly.GetExecutingAssembly());

        //***Add layers that need to reach MediatR
        services.AddMediatR(typeof(Application.DependencyInjection), typeof(Persistance.DependencyInjection));

        MapsterMapster.MapsterSetter();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        //***Adds the possibility to inject the interface instead of the concrete implementation.
        //***DbContext is not thread-safe, so the same instance should not be re-used across threads
        //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

        services.AddTransient<IBookerRepository, BookerRepository>();
        services.AddTransient<IRoomRepository, RoomRepository>();
        services.AddTransient<ITimeSlotRepository, TimeSlotRepository>();
    }

    //public static void ConfigureIdentity(this IServiceCollection services)
    //{
    //    var builder = services.AddIdentityCore<User>(o =>
    //    {
    //        o.Password.RequireDigit = true;
    //        o.Password.RequireLowercase = false;
    //        o.Password.RequireUppercase = false;
    //        o.Password.RequireNonAlphanumeric = false; o.Password.RequiredLength = 10;
    //        o.User.RequireUniqueEmail = true;
    //    });
    //    builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
    //    builder.AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
    //}

}