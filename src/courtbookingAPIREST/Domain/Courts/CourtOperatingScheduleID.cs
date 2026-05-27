namespace courtbookingAPIREST.Domain.Courts;

public readonly record struct CourtOperatingScheduleID(Guid Value)
{
    public static CourtOperatingScheduleID New() => new(Guid.NewGuid());
    public static CourtOperatingScheduleID From(Guid value) => new(value);
    public override string ToString() => Value.ToString();
}
