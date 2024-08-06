using System;
using System.Text;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Services;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Infrastucture.Extensions;
using SistemaTerapeutico.Infrastucture.Filters;
using SistemaTerapeutico.Infrastucture.Repositorios;
using SistemaTerapeutico.Infrastucture.Services;

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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IParticipanteRepository, ParticipanteRepository>();
            services.AddTransient<IPersonaRepository, PersonaRepository>();
            services.AddTransient<IPersonaDocumentoRepository, PersonaDocumentoRepository>();
            services.AddTransient<IPersonaContactoRepository, PersonaContactoRepository>();
            services.AddTransient<IPersonaVinculacionRepository, PersonaVinculacionRepository>();
            services.AddTransient<IDireccionRepository, DireccionRepository>();
            services.AddTransient<IAtencionRepository, AtencionRepository>();
            services.AddTransient<ITerapiaRepository, TerapiaRepository>();
            services.AddTransient<IPeriodoRepository, PeriodoRepository>();
            services.AddTransient<ISesionRepository, SesionRepository>();
            services.AddTransient<ISesionCriterioRepository, SesionCriterioRepository>();
            services.AddTransient<ISesionCriterioViewRepository, SesionCriterioViewRepository>();
            services.AddTransient<ITerapiaPeriodoRepository, TerapiaPeriodoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IPersonaResumenViewRepository, PersonaResumenViewRepository>();
            services.AddTransient<IParticipanteResumenViewRepository, ParticipanteResumenViewRepository>();
            services.AddTransient<IPersonaNaturalViewRepository, PersonaNaturalViewRepository>();
            services.AddTransient<IUbigeoViewRepository, UbigeoViewRepository>();
            services.AddTransient<ICatalogoRepository, CatalogoRepository>();
            services.AddTransient<ILocalViewRepository, LocalViewRepository>();
            services.AddTransient<ISalonViewRepository, SalonViewRepository>();
            services.AddTransient<ITarifaViewRepository, TarifaViewRepository>();
            services.AddTransient<ITerapiaHorarioRepository, TerapiaHorarioRepository>();
            services.AddTransient<ITerapiaTerapeutaRepository, TerapiaTerapeutaRepository>();
            services.AddTransient<ITerapiaParticipanteRepository, TerapiaParticipanteRepository>();
            services.AddTransient<ITerapiaParticipanteResumenViewRepository, TerapiaParticipanteResumenViewRepository>();
            services.AddTransient<ITerapiaPeriodoResumenViewRepository, TerapiaPeriodoResumenViewRepository>();
            services.AddTransient<ITarifaRepository, TarifaRepository>();
            services.AddTransient<IAreaObjetivoCriterioViewRepository, AreaObjetivoCriterioViewRepository>();
            services.AddTransient<ITerapiaPlanRepository, TerapiaPlanRepository>();
            services.AddTransient<ITerapiaPlanViewRepository, TerapiaPlanViewRepository>();
            services.AddTransient<ITerapiaPlanResumenViewRepository, TerapiaPlanResumenViewRepository>();
            services.AddTransient<ITerapiaPlanAreaRepository, TerapiaPlanAreaRepository>();
            services.AddTransient<ITerapiaPlanAreaViewRepository, TerapiaPlanAreaViewRepository>();
            services.AddTransient<IModeloRepository, ModeloRepository>();
            services.AddTransient<IPuntuacionGrupoRepository, PuntuacionGrupoRepository>();

            services.AddSingleton<IPasswordService, PasswordService>();

            services.AddOptions(Configuration);

            services.AddDbContext<SISDETContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("SISDET"))
            );

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Authentication:Issuer"],
                    ValidAudience = Configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]))
                };
            });

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

            services.AddTransient<IParticipanteService, ParticipanteService>();
            services.AddTransient<IPersonaService, PersonaService>();
            services.AddTransient<IPersonaVinculacionService, PersonaVinculacionService>();
            services.AddTransient<IPersonaDocumentoService, PersonaDocumentoService>();
            services.AddTransient<IDireccionService, DireccionService>();
            services.AddTransient<IAtencionService, AtencionService>();
            services.AddTransient<ITerapiaService, TerapiaService>();
            services.AddTransient<ITerapiaPlanService, TerapiaPlanService>();
            services.AddTransient<IPeriodoService, PeriodoService>();
            services.AddTransient<ISesionService, SesionService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IUbigeoViewService, UbigeoViewService>();
            services.AddTransient<ICatalogoService, CatalogoService>();
            services.AddTransient<ILocalService, LocalService>();
            services.AddTransient<ISalonService, SalonService>();
            services.AddTransient<IServicioService, ServicioService>();
            services.AddTransient<IModeloService, ModeloService>();
            services.AddTransient<IPuntuacionService, PuntuacionService>();

            services.AddScoped(typeof(IBaseEntityRepository<>), typeof(BaseEntityRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddSwaggerGen(config =>
            {
                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                    "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
            });
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}

