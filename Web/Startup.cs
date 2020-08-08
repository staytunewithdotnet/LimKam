using LimKam.Config;
using LimKam.Domain.Models;
using LimKam.Domain.Repositories;
using LimKam.Domain.Repositories.User;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();
            services.Configure<IISOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("CQRS_SAMPLE");
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();

            //services.AddMediatR(this.GetType().Assembly);
            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(IUserRepository).Assembly);

            services.AddMvc()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = InvalidModelStateResponseFactory.ProduceErrorResponse;
                });

            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CQRS with MediatR - Example API",
                    Version = "v1",
                    Description = "Simple API built to demonstrate how to use CQRS with MediatR in ASP.NET Core applications.",
                    //Contact = new Contact
                    //{
                    //    Name = "Evandro Gayer Gomes",
                    //    Url = "https://github.com/evgomes",
                    //},
                    //License = new License
                    //{
                    //    Name = "MIT",
                    //},
                });


                //services.AddControllersWithViews();
                services.AddControllers();

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseBrowserLink();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRS with MediatR - Example API v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
