using Integracao.IoC;
using Integracao.Worker.Workers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;

        services.RegisterServices(configuration);

        services.AddHostedService<ProdutoIntegracaoWorker>();
    })
    .ConfigureLogging((context, logging) =>
    {
        var env = context.HostingEnvironment;
        var config = context.Configuration.GetSection("Logging");

        logging.AddConfiguration(config);
        logging.AddConsole();

        // Para exibir somente os logs de aviso
        logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
    })
    .Build();

await host.RunAsync();
