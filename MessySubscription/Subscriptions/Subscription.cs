
using HotChocolate;
using HotChocolate.Types;
using MessySubscription.Schema;

namespace MessySubscription.Subscriptions;
public class Subscription
{
    [Topic, Subscribe]
    public Consumable ConsumableAdded([EventMessage] Consumable consumable)
    {
        return consumable;
    }
}
