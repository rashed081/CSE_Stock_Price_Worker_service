using Autofac;
using Autofac.Extensions.DependencyInjection;
using CSEData.Scrapper;
using CSEData.Worker;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");
//Console.WriteLine(connectionString);
var migrationAssemblyName = typeof(Worker).Assembly.FullName;
//Console.WriteLine(migrationAssemblyName);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

try
{
    IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .UseSerilog()
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new WorkerModule());
        builder.RegisterModule(new ScrapperModule(connectionString, migrationAssemblyName));
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddDbContext<StockDbContext>(options =>
            options.UseSqlServer(connectionString, m => m.MigrationsAssembly(migrationAssemblyName)));
    })
    .Build();

    Log.Information("Application starting up!");
    await host.RunAsync();
}
catch (Exception ex)
{
    Log.Error(ex.Message);
}
finally
{
    Log.CloseAndFlush();
}