namespace courtbookingAPIREST.Domain.Courts;

public class CourtTimeSlot
{
    public CourtTimeSlotID Id { get; private set; }
    public CourtID CourtId { get; private set; }
    public DateOnly Date { get; private set; }
    public TimeSpan Start { get; private set; }
    public TimeSpan End { get; private set; }
    public SlotStatus Status { get; private set; }

    private CourtTimeSlot() { }

    public static CourtTimeSlot Create(CourtID courtId, DateOnly date, TimeSpan start, TimeSpan end) => new()
    {
        Id = CourtTimeSlotID.New(),
        CourtId = courtId,
        Date = date,
        Start = start,
        End = end,
        Status = SlotStatus.Available
    };

    public void Book()     => Status = SlotStatus.Booked;
    public void Cancel()   => Status = SlotStatus.Available;
    public void Invalidate() => Status = SlotStatus.Cancelled;
}

public enum SlotStatus { Available, Booked, Cancelled }
