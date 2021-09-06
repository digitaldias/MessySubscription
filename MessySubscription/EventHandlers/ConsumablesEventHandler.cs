
using HotChocolate.Subscriptions;
using MessySubscription.Events;
using MessySubscription.Subscriptions;
using PubSub;

namespace MessySubscription.EventHandlers;
public class ConsumablesEventHandler
{    
    readonly ITopicEventSender _topicEventSender;

    public ConsumablesEventHandler(ITopicEventSender topicEventSender)
    {        
        _topicEventSender = topicEventSender;

        Hub.Default.Subscribe<ConsumableAdded>(PublishToGraphQlSubscription);
    }

    private void PublishToGraphQlSubscription(ConsumableAdded consumableAddedEvent)
    {
        if(consumableAddedEvent.Consumable is { })
        {
            _topicEventSender.SendAsync(nameof(Subscription.ConsumableAdded), consumableAddedEvent.Consumable);
        }
    }
}
