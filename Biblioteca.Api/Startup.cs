using Biblioteca.Domain.LivroContext;
using Biblioteca.Domain.LocacaoContext;
using Biblioteca.Infra;
using Biblioteca.Infra.Repository.LivroContext;
using Biblioteca.Infra.Repository.LocacaoContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Biblioteca.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IAutorRepository, AutorRepository>();
            services.AddTransient<ILivroRepository, LivroRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<ILocacaoRepository, LocacaoRepository>();

            services.AddDbContext<BibliotecaContext>(options => options.UseSqlServer(@"Server=.;Database=Biblioteca;Integrated Security=True"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
                var context = serviceScope.ServiceProvider.GetRequiredService<BibliotecaContext>();
                context.Database.Migrate();
            }
        }
    }
}
