using Shopper.Domain.Models;

namespace Shopper.Domain.Extensions;


public static class ModelsExtensions
{
    public static string? Name(this Customer? customer) 
    {
        return $"{customer?.FirstName} {customer?.LastName}";
    }
}