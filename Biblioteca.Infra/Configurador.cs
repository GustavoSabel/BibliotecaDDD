using Biblioteca.Domain.Common.Events;
using Biblioteca.Domain.LivroContext;
using Biblioteca.Domain.LocacaoContext;
using Biblioteca.Infra.Repository.LivroContext;
using Biblioteca.Infra.Repository.LocacaoContext;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Biblioteca.Infra
{
    public static class Configurador
    {
        public static void Configurar(IServiceCollection services, bool desenvolvimento)
        {
            services.AddTransient<IAutorRepository, AutorRepository>();
            services.AddTransient<ILivroRepository, LivroRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<ILocacaoRepository, LocacaoRepository>();

            services.AddDbContext<BibliotecaContext>(options =>
            {
                BibliotecaContext.Configurar(options, @"Server=.;Database=Biblioteca;Integrated Security=True", desenvolvimento);
            });

            services.AddMediatR(typeof(LivroAlugadoEvent).GetTypeInfo().Assembly);
            services.AddTransient<IBus, Bus>();
        }
    }
}
