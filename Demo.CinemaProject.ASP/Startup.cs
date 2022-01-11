using Demo.CinemaProject.BLL.Entities;
using Demo.CinemaProject.BLL.Services;
using Demo.CinemaProject.Common.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.CinemaProject.ASP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddScoped<ICinemaRepository<DAL.Entities.Cinema>, DAL.Repositories.CinemaService>();
            services.AddScoped<IFilmRepository<DAL.Entities.Film>, DAL.Repositories.FilmService>();
            services.AddScoped<IDiffusionRepository<DAL.Entities.Diffusion>, DAL.Repositories.DiffusionService>();
            services.AddScoped<ICinemaRepository<Cinema>, CinemaService>();
            services.AddScoped<IFilmRepository<Film>, FilmService>();
            services.AddScoped<IDiffusionRepository<Diffusion>, DiffusionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
