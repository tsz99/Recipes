using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Recipes.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.Services
{
    public class DataCollectorService : IHostedService, IDisposable
    {
        private readonly ILogger<DataCollectorService> _logger;
        private RecipesRepository repo;
        private Timer _timer;
        public DataCollectorService(ILogger<DataCollectorService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            this.repo = scopeFactory.CreateScope().ServiceProvider.GetRequiredService<RecipesRepository>();
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is starting.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(15));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private void DoWork(object o)
        {
            //Todo logic here, API call and stuff
            Console.WriteLine("Work");
        }
    }
}
