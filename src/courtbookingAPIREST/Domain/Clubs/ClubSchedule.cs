namespace courtbookingAPIREST.Domain.Clubs;

public class ClubSchedule
{
    private static readonly TimeZoneInfo ZonaUruguay =
        TimeZoneInfo.FindSystemTimeZoneById("America/Montevideo");

    public ClubScheduleID Id { get; private set; }
    public DayOfWeek DayOfWeek { get; private set; }
    public TimeSpan OpeningTime { get; private set; }
    public TimeSpan ClosingTime { get; private set; }

    private ClubSchedule()
    {
        DayOfWeek = default;
        OpeningTime = default;
        ClosingTime = default;
    }

    public static ClubSchedule Create(DayOfWeek dayOfWeek, TimeSpan openingTime, TimeSpan closingTime) =>
        new()
        {
            Id = ClubScheduleID.New(),
            DayOfWeek = dayOfWeek,
            OpeningTime = openingTime,
            ClosingTime = closingTime
        };

    public bool ClosesNextDay() => ClosingTime <= OpeningTime;

    public bool IsOpen(DateTimeOffset dateTime)
    {
        var local = TimeZoneInfo.ConvertTime(dateTime, ZonaUruguay);
        var day = local.DayOfWeek;
        var time = local.TimeOfDay;

        if (!ClosesNextDay())
            return day == DayOfWeek && time >= OpeningTime && time < ClosingTime;

        var nextDay = (DayOfWeek)(((int)DayOfWeek + 1) % 7);

        if (day == DayOfWeek) return time >= OpeningTime;
        if (day == nextDay) return time < ClosingTime;

        return false;
    }
}
