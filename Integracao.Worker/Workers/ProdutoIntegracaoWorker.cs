using Integracao.Domain.Interfaces.Services;

namespace Integracao.Worker.Workers
{
    public class ProdutoIntegracaoWorker : BackgroundService
    {
        private readonly ILogger<ProdutoIntegracaoWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public ProdutoIntegracaoWorker(
            ILogger<ProdutoIntegracaoWorker> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();
                using var integracaoService = scope.ServiceProvider.GetRequiredService<IIntegracaoService>();

                await integracaoService.IntegrarProdutos();

                await Task.Delay(2000, stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(ProdutoIntegracaoWorker)} está parando.");

            await base.StopAsync(stoppingToken);
        }
    }
}
