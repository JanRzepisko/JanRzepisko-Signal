using MultiCultiChat.App.Application;
using MultiCultiChat.App.Application.DataAccess;
using MultiCultiChat.App.Application.Hubs;
using MultiCultiChat.App.Application.Services;
using MultiCultiChat.App.Infrastructure.DataAccess;
using MultiCultiChat.App.Infrastructure.Services;
using Shared.BaseModels.LoginObject;
using Shared.Extensions.ConfigureApp;
using Shared.Extensions.ConfigureServices;

namespace MultiCultiChat.App.API;

public class Startup
{
    public Startup(IConfiguration configuration) => Configuration = configuration;

    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Configuration["ConnectionString"];
        var serviceName = Configuration["ServiceName"];

        //Configure Service
        services.Configure<string>(Configuration);
        services.AddSharedServices<AssemblyEntryPoint, DataContext, IUnitOfWork>(JwtLogin.FromConfiguration(Configuration), connectionString, serviceName);

        services.AddTransient<IJwtAuth, JwtAuth>();
        
        services.AddSignalR();

        //services.AddMessageBusConnection(c => c.ApplyConfiguration(Configuration.GetSection("RabbitMQ")));
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.ConfigureApplication(Configuration);
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHub<MessageHub>("/messages");
        });
    }
}