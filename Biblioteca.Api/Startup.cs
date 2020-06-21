using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Biblioteca.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironmen)
        {
            Configuration = configuration;
            WebHostEnvironmen = webHostEnvironmen;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironmen { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            Infra.Configurador.Configurar(services, WebHostEnvironmen.IsDevelopment());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API da Biblioteca", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API da Biblioteca V1"));

            app.UseRouting();

            app.UseCors(x =>
            {
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
                x.AllowAnyHeader();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            MigrarBancoDados(app);
        }

        private static void MigrarBancoDados(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<Infra.BibliotecaContext>();
                context.Database.Migrate();
            }
        }
    }
}
