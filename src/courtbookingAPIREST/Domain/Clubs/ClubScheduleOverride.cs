namespace courtbookingAPIREST.Domain.Clubs;

public class ClubScheduleOverride
{
    public ClubScheduleOverrideID Id { get; private set; }
    public DateOnly Date { get; private set; }
    public string Reason { get; private set; }
    public bool IsClosed { get; private set; }
    public TimeSpan? OpeningTime { get; private set; }
    public TimeSpan? ClosingTime { get; private set; }

    private ClubScheduleOverride()
    {
        Reason = null!;
    }

    // El club cierra ese día completo
    public static ClubScheduleOverride CreateDayClosure(DateOnly date, string reason) => new()
    {
        Id = ClubScheduleOverrideID.New(),
        Date = date,
        Reason = reason,
        IsClosed = true
    };

    // El club opera con horario distinto ese día
    public static ClubScheduleOverride CreateModifiedHours(
        DateOnly date, string reason, TimeSpan openingTime, TimeSpan closingTime) => new()
    {
        Id = ClubScheduleOverrideID.New(),
        Date = date,
        Reason = reason,
        IsClosed = false,
        OpeningTime = openingTime,
        ClosingTime = closingTime
    };
}

//TODO: Business Rule: Si el club cierra por feriado/motivo extra, debería cerrar el overflow
// al día siguiente? A decidir.
