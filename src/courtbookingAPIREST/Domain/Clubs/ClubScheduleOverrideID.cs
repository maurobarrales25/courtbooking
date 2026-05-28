namespace courtbookingAPIREST.Domain.Clubs;

public readonly record struct ClubScheduleOverrideID(Guid Value)
{
    public static ClubScheduleOverrideID New() => new(Guid.NewGuid());
    public static ClubScheduleOverrideID From(Guid value) => new(value);
    public override string ToString() => Value.ToString();
}
