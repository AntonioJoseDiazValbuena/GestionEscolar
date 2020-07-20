using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionEscolar.Aplicacion;
using GestionEscolar.Aplicacion.Interfaces;
using GestionEscolar.Datos;
using GestionEscolar.Datos.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GestionEscolar.API
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
            services.AddDbContext<GestionEscolarContexto>(config =>
                {
                    config.UseSqlServer(Configuration.GetConnectionString("ConexionSQLServer"));
                });
            services.AddControllers().AddNewtonsoftJson();
            services.AddScoped<IGestionEscolarContexto, GestionEscolarContexto>();
            services.AddScoped<IGestionEstudiante, GestionEstudiante>();
            services.AddScoped<IGestionProfesor, GestionProfesor>();
            services.AddScoped<IGestionMateria, GestionMateria>();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            UpdateDatabase(app);

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

        private void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<GestionEscolarContexto>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
