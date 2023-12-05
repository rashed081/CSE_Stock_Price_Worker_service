using CSEData.Scrapper;

namespace CSEData.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IScrapper _scrapper;
        private readonly IStockDbContext _dbContext;

        public Worker(ILogger<Worker> logger, IScrapper scrapper, IStockDbContext dbContext)
        {
            _logger = logger;
            _scrapper = scrapper;
            _dbContext = dbContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Data Stored into databased at {time}", DateTimeOffset.Now);
                //Console.WriteLine(DateTime.Now);
                var dbManager = new DatabaseManager(_dbContext);
                dbManager.StoreStockData(await _scrapper.GetCurrentPriceAsync());

                await Task.Delay(60000, stoppingToken);

            }
        }
    }
}