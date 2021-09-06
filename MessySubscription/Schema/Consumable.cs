namespace MessySubscription.Schema;

public class Consumable
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DateTime CreatedDate { get; set; }    

    public static Consumable GenerateRandomConsumable()
    {
        var random = new Random((int)DateTime.Now.Ticks);
        
        return new Consumable
        {
            Id = Guid.NewGuid(),
            CreatedDate = DateTime.Now.AddDays(random.Next(-365, 365)),
            Name = Faker.Address.City() + " Lemon"
        };
    }
}
