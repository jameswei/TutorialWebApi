using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TutorialWebApi
{
    // The Startup class configures services collection and request-response processing pipeline.
    // It's named as Startup by convension, we can give it any name, as long as specify to the UseStartup<StartupClassName> in the Program class.s 
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // The generated code of Startup class.
        // We can configure the services required by the application.
        // Service is a reusable component that provides functionality.
        // Service can be consumed across the application via Dependency Injection (DI) if registered.
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // There's a built-in service container, IServiceProvider, where services are typically registered.
            // You can simply think the registration is mapping between the service interface and the implementation.
            // For interface InfB use the implementation of class B.
            // service can be registered with one of the following lifetime: Transient, Scoped, or Singleton.

            // Transient lifetime service is created each time when it's requested, it works best for lightweight and stateless service.
            // services.AddTransient<InfB, B>();

            // Scoped lifetime service is created once per client requested.
            // services.AddScoped<InfB, B>();

            // Singleton lifetime service is created only at first time when it's created.
            // services.AddSingleton<InfB, B>();
        }

        // The generated code of Startup class.
        // Define how to handle the application's request, as a series of middleware components, AKA, filter chain. 
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // As you can see, there're several UserSomething methods.
            // Each one of these is a middleware component attached to the request-response pipeline.
            // The order is critical for security, performance, and functionality. eg, authorization should be placed before sever endpoints.
            // ASP.NET provides several built-in middleware components for the most common use-cases, eg, authentication, authorization, cors, forwarded-headers, and session support.
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
    }
}
