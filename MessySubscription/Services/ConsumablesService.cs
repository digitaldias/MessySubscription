
using MessySubscription.Events;
using MessySubscription.Schema;
using PubSub;

namespace MessySubscription.Services;
public class ConsumablesService : IHostedService, IAsyncDisposable
{        
    Timer _timer;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(PushConsumable, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));
        return Task.CompletedTask;
    }

    private void PushConsumable(object? state)
    {

        var eventToPublish = new ConsumableAdded
        { 
            Consumable = Consumable.GenerateRandomConsumable() 
        };
        Hub.Default.Publish(eventToPublish);    
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public async ValueTask DisposeAsync()
    {
        if(_timer is IAsyncDisposable timer)
        {
            await timer.DisposeAsync();
        }
        _timer = null;
    }
}
