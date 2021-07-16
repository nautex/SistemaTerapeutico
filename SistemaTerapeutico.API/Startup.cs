using System;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Services;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Infrastucture.Filters;
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
            services.AddControllers(options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();
            });

            services.AddTransient<IPersonaRepository, PersonaRepository>();
            services.AddTransient<IPersonaDocumentoRepository, PersonaDocumentoRepository>();
            services.AddTransient<IPersonaContactoRepository, PersonaContactoRepository>();
            services.AddTransient<IPersonaVinculacionRepository, PersonaVinculacionRepository>();
            services.AddTransient<IDireccionRepository, DireccionRepository>();

            services.AddDbContext<SISDETContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("SISDET"))
            );

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddMvc(options =>
                options.Filters.Add<ValidationFilter>()
            );

            services.AddFluentValidation(options =>
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
            );

            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyCors", builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

            services.AddTransient<IPersonaService, PersonaService>();
            services.AddTransient<IPersonaVinculacionService, PersonaVinculacionService>();
            services.AddTransient<IPersonaDocumentoService, PersonaDocumentoService>();
            services.AddTransient<IDireccionService, DireccionService>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("MyCors");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
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

