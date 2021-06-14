using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SistemaTerapeutico.Aplicacion.Servicios.Persona;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Infrastucture.Repositorios;

namespace SistemaTerapeutico.BackEnd.API
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
            services.AddControllers();

            services.AddDbContext<SISDETContext>(options =>
              options.UseMySQL(Configuration.GetConnectionString("SISDET"))
            );

            services.AddScoped<IRepository, Repository>();
            AgregarServicios(services);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        private static void AgregarServicios(IServiceCollection services)
        {
            services.AddScoped<IObtenerdorPersonasServicio, ObtenedorPersonasServicio>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
