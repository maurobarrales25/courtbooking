namespace courtbookingAPIREST.Domain.Courts;

public class CourtOperatingSchedule
{
    public CourtOperatingScheduleID Id { get; private set; }
    public DayOfWeek DayOfWeek { get; private set; }
    public TimeSpan OpeningTime { get; private set; }
    public TimeSpan ClosingTime { get; private set; }

    private CourtOperatingSchedule() { }

    public static CourtOperatingSchedule Create(
        DayOfWeek dayOfWeek, TimeSpan openingTime, TimeSpan closingTime) => new()
    {
        Id = CourtOperatingScheduleID.New(),
        DayOfWeek = dayOfWeek,
        OpeningTime = openingTime,
        ClosingTime = closingTime
    };
}
