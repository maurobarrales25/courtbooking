namespace courtbookingAPIREST.Domain.Geography;

public record City(string Name, State State)
{
    private City() : this(string.Empty, null!) { }
}
