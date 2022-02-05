using Autofac;
using  Framework.Core.Bus;
using Framework.Core.Persistence;
using MassTransit;
using Mc2.CrudTest.Application.Contract.Customer;
using Mc2.CrudTest.Application.CustomerHandler;
using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Persistence;
using Mc2.CrudTest.QueryService;
using Mc2.CrudTest.QueryService.Contract.ServiceContract;
using Mc2.CrudTest.QueryService.EventHandler;
using Mc2.CrudTest.QueryService.QueryHandler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Mc2.CrudTest.Presentation.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CrudTestApi", Version = "v1" });
            });

            services.AddMassTransit(x =>
            {
                //// TODO: Auto Register Consumers
               x.AddConsumer<CustomerRegistredEventHandler>();
                // x.UsingRabbitMq();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ReceiveEndpoint("Mc2_QueryModel", e =>
                    {
                        e.ConfigureConsumer<CustomerRegistredEventHandler>(context);
                    });
                });
            });

            services.AddMassTransitHostedService();
            DbConnectionFactory.SetConfiguration(Configuration);
        }


        public void ConfigureContainer(ContainerBuilder builder)
        {
            Framework.Configuration.Autofac.DependencyConfigurator.Config(builder);
          
            //TODO Auto Register
            builder.RegisterType<RegisterCustomerCommandHandler>().As<ICommandHandler<RegisterCustomerCommand>>();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<CustomerQueryService>().As<ICustomerQueryService>();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CrudTestApi v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
