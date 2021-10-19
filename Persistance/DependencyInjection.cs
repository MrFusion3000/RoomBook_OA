using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Application.Interfaces;
using Persistance.Repositories.Bookers;
using Persistance.Repositories.Rooms;
using Persistance.Repositories.TimeSlots;

namespace Persistance
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {           
            /// Use MediatR in the active layer
            //services.AddMediatR(Assembly.GetExecutingAssembly());

            /// Add layers that need to reach MediatR
            services.AddMediatR(typeof(Application.DependencyInjection), typeof(Persistance.DependencyInjection));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            services.AddScoped<ApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddTransient<IBookerRepository, BookerRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<ITimeSlotRepository, TimeSlotRepository>();


            //services.AddIdentity<APIUser, UserRole>()
            //    .AddDefaultTokenProviders();
            //services.AddScoped<IUserStore<APIUser>, UserStore>();
            //services.AddScoped<IRoleStore<UserRole>, RoleStore>();
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
            });
        }

    }

    
}
