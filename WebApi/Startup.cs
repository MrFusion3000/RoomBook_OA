using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Mapster;
using Domain.Entities;
using Application.Shared.DTO;

namespace WebApi
{
    public class Startup
    {
        //private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        private readonly IWebHostEnvironment _env;

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region AddCors
            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: MyAllowSpecificOrigins,
            //                  builder =>
            //                  {
            //                      builder.WithOrigins("https://localhost:44372",
            //                                          "https://localhost:44315",
            //                                          "https://localhost:81",
            //                                          "https://localhost:82")
            //                      .AllowAnyHeader()
            //                      .AllowAnyMethod();
            //                  });
            //});
            services.AddCors();
            #endregion

            services.AddControllers(options =>
            {
                options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
            });

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(string.Format(@"{0}\RoomBook_OA.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "RoomBook_OA",
                });

            });
            #endregion

            #region Api Versioning
            // Add API Versioning to the Project
            services.AddApiVersioning(config =>
            {
                // Specify the default API Version as 1.0
                config.DefaultApiVersion = new ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number 
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = true;
            });
            #endregion

            #region Identity
            //This section is placed in Persistance/DependencyInjection.cs
            #endregion

            services.AddPersistence(Configuration);

            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env/*, SignInManager<User> s*/)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseCors(MyAllowSpecificOrigins);
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseBlazorFrameworkFiles();

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseAuthorization();

            #region Seed user
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseBrowserLink();

            //    if (s.UserManager.FindByNameAsync("dev").Result == null)
            //    {
            //        var result = s.UserManager.CreateAsync(new User
            //        {
            //            UserName = "dev",
            //            Email = "dev@app.com"
            //        }, "Aut94L#G-a").Result;
            //    }
            //}
            #endregion

            app.UseAuthentication();

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            #endregion

            app.UseDeveloperExceptionPage();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/echo",
            //    context => context.Response.WriteAsync("echo"))
            //    .RequireCors(MyAllowSpecificOrigins);

            //    endpoints.MapControllers();
            //});

            //app.UseEndpoints(endpoints => endpoints.MapHealthChecks("/health"));

            app.UseEndpoints(x => x.MapControllers());
        }
    }
}
