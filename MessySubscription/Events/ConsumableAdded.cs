using MessySubscription.Schema;

namespace MessySubscription.Events
{
    public class ConsumableAdded
    {
        public Consumable? Consumable { get; set; }
    }
}