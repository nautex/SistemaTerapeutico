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
            services.AddTransient<ITerapiaPeriodoRepository, TerapiaPeriodoRepository>();
            services.AddTransient<ITerapiaPlanificacionRepository, TerapiaPlanificacionRepository>();
            services.AddTransient<ITerapiaPlanificacionCriterioRepository, TerapiaPlanificacionCriterioRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IPersonaViewRepository, PersonaResumenViewRepository>();
            services.AddTransient<IParticipanteViewRepository, ParticipanteResumenViewRepository>();

            services.AddSingleton<IPasswordService, PasswordService>();

            services.AddOptions(Configuration);

            services.AddDbContext<SISDETContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("SISDET"))
            );

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
            services.AddTransient<IPeriodoService, PeriodoService>();
            services.AddTransient<ISesionService, SesionService>();
            services.AddTransient<ISesionCriterioService, SesionCriterioService>();
            services.AddTransient<ITerapiaPeriodoService, TerapiaPeriodoService>();
            services.AddTransient<ITerapiaPlanificacionService, TerapiaPlanificacionService>();
            services.AddTransient<ITerapiaPlanificacionCriterioService, TerapiaPlanificacionCriterioService>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
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

