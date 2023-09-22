using Shared.BaseModels.LoginObject;
using Shared.Extensions.ConfigureApp;
using Shared.Extensions.ConfigureServices;
using Signal.App.Application;
using Signal.App.Application.DataAccess;
using Signal.App.Application.Hubs;
using Signal.App.Infrastructure.DataAccess;

namespace Signal.App.API;

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