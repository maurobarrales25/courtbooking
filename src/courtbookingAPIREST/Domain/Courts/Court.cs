using courtbookingAPIREST.Domain.Clubs;

namespace courtbookingAPIREST.Domain.Courts;

public class Court
{
    public CourtID Id { get; private set; }
    public string Name { get; private set; }
    public TimeSpan SlotDuration { get; private set; }
    public ClubID ClubId { get; private set; }

    // Si true, usa OperatingSchedules propios en lugar del horario del club.
    // SIEMPRE respeta ClubScheduleException sin excepción.
    public bool OverridesClub { get; private set; }
    public CourtType Type { get; private set; }
    public ICollection<CourtOperatingSchedule> OperatingSchedules { get; private set; } = [];

    private Court()
    {
        Name = null!;
    }

    public static Court Create(string name, TimeSpan slotDuration, ClubID clubId, bool overridesClub = false, CourtType type = CourtType.Cesped) => new()
    {
        Id = CourtID.New(),
        Name = name,
        SlotDuration = slotDuration,
        ClubId = clubId,
        OverridesClub = overridesClub,
        Type = type
    };

    public IReadOnlyList<CourtTimeSlot> GenerateSlots(DateOnly date, Clubs.Club club)
    {
        var windows = GetAvailableWindows(date, club);
        var slots = new List<CourtTimeSlot>();

        foreach (var (windowStart, windowEnd) in windows)
        {
            var cursor = windowStart;
            while (cursor + SlotDuration <= windowEnd)
            {
                slots.Add(CourtTimeSlot.Create(Id, date, cursor, cursor + SlotDuration));
                cursor += SlotDuration;
            }
        }

        return slots;
    }

    private IReadOnlyList<(TimeSpan Start, TimeSpan End)> GetAvailableWindows(DateOnly date, Clubs.Club club)
    {
        var exception = club.GetScheduleOverride(date);

        // La excepción de cierre aplica siempre, sin importar si la cancha sobrescribe o no
        if (exception?.IsClosed == true) return [];

        if (!OverridesClub)
            return club.GetOpenWindows(date); // ya tiene la excepción aplicada

        // La cancha tiene su propio horario: tomar schedules propios del día
        var ownWindows = OperatingSchedules
            .Where(s => s.DayOfWeek == date.DayOfWeek)
            .Select(s => (s.OpeningTime, s.ClosingTime))
            .ToList();

        if (ownWindows.Count == 0) return [];

        var merged = MergeWindows(ownWindows);

        // Aplicar excepción de horario modificado como restricción sobre el horario propio
        if (exception is { IsClosed: false })
        {
            var exWindow = (exception.OpeningTime!.Value, exception.ClosingTime!.Value);
            return Intersect(merged, exWindow);
        }

        return merged;
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

    // Recorta cada ventana propia dentro del límite impuesto por la excepción
    private static List<(TimeSpan Start, TimeSpan End)> Intersect(
        IEnumerable<(TimeSpan Start, TimeSpan End)> windows,
        (TimeSpan Start, TimeSpan End) limit)
    {
        var result = new List<(TimeSpan, TimeSpan)>();

        foreach (var (start, end) in windows)
        {
            var intersectStart = start < limit.Start ? limit.Start : start;
            var intersectEnd   = end   > limit.End   ? limit.End   : end;

            if (intersectStart < intersectEnd)
                result.Add((intersectStart, intersectEnd));
        }

        return result;
    }
}



