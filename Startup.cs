using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignalRSimpleChat.Repository;
using SignalRSimpleChat.Services;

namespace SignalRSimpleChat
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
            services.AddMvc();

            services.AddSignalR();

            services.AddScoped(typeof(IChatService), typeof(ChatService));
            services.AddScoped(typeof(NetchatContext), typeof(NetchatContext));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {         
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
	            endpoints.MapRazorPages();
	            endpoints.MapHub<Chat>($"/{nameof(Chat)}");
            });
        }
    }
}
