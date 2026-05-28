using courtbookingAPIREST.Domain.Geography;
using CourtEntity = courtbookingAPIREST.Domain.Courts.Court;

namespace courtbookingAPIREST.Domain.Clubs;

public class Club
{
    private static readonly TimeZoneInfo ZonaUruguay =
        TimeZoneInfo.FindSystemTimeZoneById("America/Montevideo");

    public ClubID Id { get; private set; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public Location Location { get; private set; }
    public ICollection<ClubSchedule> Schedules { get; private set; } = [];
    public ICollection<ClubScheduleException> ScheduleExceptions { get; private set; } = [];
    public ICollection<Courts.Court> Courts { get; private set; } = [];

    private Club()
    {
        Name = null!;
        Address = null!;
        Location = null!;
    }

    public static Club Create(string name, string address, Location location) => new()
    {
        Id = ClubID.New(),
        Name = name,
        Address = address,
        Location = location
    };

    public ClubScheduleException? GetScheduleException(DateOnly date) =>
        ScheduleExceptions.FirstOrDefault(e => e.Date == date);

    public bool IsClosedOn(DateOnly date) =>
        GetScheduleException(date)?.IsClosed == true;

    public void AddException(ClubScheduleException exception)
    {
        if (GetScheduleException(exception.Date) is null)
            ScheduleExceptions.Add(exception);
    }

    public void RemoveException(DateOnly date)
    {
        var exception = GetScheduleException(date);
        if (exception is not null)
            ScheduleExceptions.Remove(exception);
    }

    public bool IsOpen(DateTimeOffset dateTime)
    {
        var local = TimeZoneInfo.ConvertTime(dateTime, ZonaUruguay);
        var date = DateOnly.FromDateTime(local.DateTime);
        return !IsClosedOn(date) && Schedules.Any(s => s.IsOpen(dateTime));
    }

    // Ventanas operativas del club para una fecha, con excepciones aplicadas.
    // Usado por Court para heredar el horario del club.
    public IReadOnlyList<(TimeSpan Start, TimeSpan End)> GetOpenWindows(DateOnly date)
    {
        var exception = GetScheduleException(date);

        if (exception?.IsClosed == true) return [];

        // Excepción con horario modificado: reemplaza el schedule base
        if (exception is { IsClosed: false })
            return [(exception.OpeningTime!.Value, exception.ClosingTime!.Value)];

        return GetBaseWindows(date);
    }

    // Ventanas del schedule base, sin aplicar excepciones.
    // Usado por Court cuando sobrescribe_club = true (necesita aplicar la excepción por su cuenta).
    public IReadOnlyList<(TimeSpan Start, TimeSpan End)> GetBaseWindows(DateOnly date)
    {
        var windows = new List<(TimeSpan Start, TimeSpan End)>();

        foreach (var s in Schedules.Where(s => s.DayOfWeek == date.DayOfWeek))
        {
            var end = s.ClosesNextDay() ? TimeSpan.FromHours(24) : s.ClosingTime;
            windows.Add((s.OpeningTime, end));
        }

        var prevDay = (DayOfWeek)(((int)date.DayOfWeek + 6) % 7);
        foreach (var s in Schedules.Where(s => s.DayOfWeek == prevDay && s.ClosesNextDay()))
            windows.Add((TimeSpan.Zero, s.ClosingTime));

        return MergeWindows(windows);
    }

    private static List<(TimeSpan Start, TimeSpan End)> MergeWindows(
        IEnumerable<(TimeSpan Start, TimeSpan End)> source)
    {
        var sorted = source.OrderBy(w => w.Start).ToList();
        if (sorted.Count == 0) return sorted;

        var merged = new List<(TimeSpan Start, TimeSpan End)> { sorted[0] };

        foreach (var (start, end) in sorted.Skip(1))
        {
            var (lastStart, lastEnd) = merged[^1];
            if (start <= lastEnd)
                merged[^1] = (lastStart, end > lastEnd ? end : lastEnd);
            else
                merged.Add((start, end));
        }

        return merged;
    }
}
