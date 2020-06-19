using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Biblioteca.Domain
{
    public static class Configurador
    {
        public static void Configurar(IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
