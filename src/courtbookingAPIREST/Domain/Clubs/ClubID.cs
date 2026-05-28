namespace courtbookingAPIREST.Domain.Clubs;

public readonly record struct ClubID(Guid Value)
{
    public static ClubID New() => new(Guid.NewGuid());
    public static ClubID From(Guid value) => new(value);

    public override string ToString() => Value.ToString();
}
