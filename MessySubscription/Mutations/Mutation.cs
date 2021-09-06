
using MessySubscription.Schema;

namespace MessySubscription.Mutations;
public class Mutation
{
    public async Task<Consumable> CreateConsumable(string name, DateTime createdDate)
    {
        return await Task.FromResult(new Consumable
        {
            Id = Guid.NewGuid(),
            Name = name,
            CreatedDate = createdDate
        });
    }
}
