namespace courtbookingAPIREST.Domain.Courts;

public readonly record struct CourtTimeSlotID(Guid Value)
{
    public static CourtTimeSlotID New() => new(Guid.NewGuid());
    public static CourtTimeSlotID From(Guid value) => new(value);
    public override string ToString() => Value.ToString();
}
