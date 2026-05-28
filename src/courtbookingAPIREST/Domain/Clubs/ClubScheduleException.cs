namespace courtbookingAPIREST.Domain.Clubs;

public class ClubScheduleException
{
    public ClubScheduleExceptionID Id { get; private set; }
    public DateOnly Date { get; private set; }
    public string Reason { get; private set; }
    public bool IsClosed { get; private set; }
    public TimeSpan? OpeningTime { get; private set; }
    public TimeSpan? ClosingTime { get; private set; }

    private ClubScheduleException()
    {
        Reason = null!;
    }

    // El club cierra ese día completo
    public static ClubScheduleException CreateClosure(DateOnly date, string reason) => new()
    {
        Id = ClubScheduleExceptionID.New(),
        Date = date,
        Reason = reason,
        IsClosed = true
    };

    // El club opera con horario distinto ese día
    public static ClubScheduleException CreateModifiedHours(
        DateOnly date, string reason, TimeSpan openingTime, TimeSpan closingTime) => new()
    {
        Id = ClubScheduleExceptionID.New(),
        Date = date,
        Reason = reason,
        IsClosed = false,
        OpeningTime = openingTime,
        ClosingTime = closingTime
    };
}
