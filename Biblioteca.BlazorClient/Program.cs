using Biblioteca.BlazorClient.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Biblioteca.BlazorClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            //builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddTransient(s => RestService.For<IAutorService>(CriarHttpClient()));

            await builder.Build().RunAsync();
        }

        private static HttpClient CriarHttpClient()
        {
            return new HttpClient { BaseAddress = new Uri("http://localhost:5000") };
        }

    }
}
