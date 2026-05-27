namespace courtbookingAPIREST.Domain.Geography;

public record Location(string State, string City, string? Neighborhood = null)
{
    private Location() : this(string.Empty, string.Empty) { }
}
