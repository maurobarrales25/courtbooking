namespace courtbookingAPIREST.Domain.Clubs;

public readonly record struct ClubScheduleExceptionID(Guid Value)
{
    public static ClubScheduleExceptionID New() => new(Guid.NewGuid());
    public static ClubScheduleExceptionID From(Guid value) => new(value);
    public override string ToString() => Value.ToString();
}
