namespace courtbookingAPIREST.Domain.Courts;

public readonly record struct CourtID(Guid Value)
{
    public static CourtID New() => new(Guid.NewGuid());
    public static CourtID From(Guid value) => new(value);
    public override string ToString() => Value.ToString();
}
