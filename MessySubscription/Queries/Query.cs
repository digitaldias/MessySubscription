
using MessySubscription.Schema;

namespace MessySubscription.Queries;
public class Query
{
    public Consumable GetRandomConsumable()
    {
        var random = new Random((int)DateTime.Now.Ticks);
        return new Consumable
        {
            Id = Guid.NewGuid(),
            CreatedDate = DateTime.Now.AddDays(random.Next(-365, 365)),
            Name = Faker.Address.City() + " lemon"
        };
    }
}
