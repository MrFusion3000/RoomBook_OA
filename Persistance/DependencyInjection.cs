using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Persistance.Repositories.Bookers;
using Application.Interfaces;

namespace Persistance
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(Application.DependencyInjection), typeof(Persistance.DependencyInjection));


            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddTransient<IBookerRepository, BookerRepository>();
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
