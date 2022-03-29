using Bogus;
using Bogus.DataSets;
using Shopper.Domain.Models;

namespace Shopper.Infrastructure.Fakers;

public class CustomerFaker : Faker<Customer>
{
    readonly decimal[] discounts = new decimal[] { 0.05m, 0.1m, 0.15m, 0.2m };

    public CustomerFaker()
    {
        StrictMode(true);   // pilnuje czy wszystkie właściwości modelu są objęte regułą
        RuleFor(p => p.Id, f => f.IndexFaker);
        RuleFor(p => p.FirstName, f => f.Person.FirstName);
        RuleFor(p => p.LastName, f => f.Person.LastName);
        RuleFor(p => p.Gender, f => f.Person.Gender.ToGenderType());
        RuleFor(p => p.Avatar, f => f.Person.Avatar);
    }    
}

public static class GenderExtensions
{
    public static Name.Gender ToBogusGender(this  GenderType value)
    {
        return value switch
        {

            GenderType.Woman => Name.Gender.Female,
            GenderType.Men => Name.Gender.Male,
            _ => throw new NotSupportedException()
        };
    }
    
    public static GenderType ToGenderType(this Name.Gender value)
    {
        return value switch
        {
            Name.Gender.Female => GenderType.Woman,
            Name.Gender.Male => GenderType.Men,
            _ => throw new NotSupportedException()
        };
    }
}
