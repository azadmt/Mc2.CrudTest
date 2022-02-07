using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Presentation.Front
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           
               WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddBlazoredToast();
            builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
