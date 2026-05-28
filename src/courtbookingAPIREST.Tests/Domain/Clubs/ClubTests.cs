using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using FluentAssertions.Execution;
using courtbookingAPIREST.Domain.Clubs;
using courtbookingAPIREST.Domain.Geography;

namespace courtbookingAPIREST.Tests.Domain.Clubs;

public class ClubTests
{
    //Para no repetir en cada test
   
    private static readonly Location location = new("Maldonado", "Punta del Este", "Beverly Hills");
    private static Club CreateClub()=>
        Club.Create(
            name: "Club Punta del Este",
            address: "Pedragosa Sierra 1234",
            location: location
    );

     private static readonly ClubSchedule mondaySchedule = ClubSchedule.Create(
        DayOfWeek.Monday,
        TimeSpan.FromHours(12), 
        TimeSpan.FromHours(23)
    );

    [Fact]
    public void IsOpen_NoSchedules_ReturnsFalse()
    {
        var club = CreateClub();    
        var dateTime = new DateTimeOffset(
            new DateTime(2026, 6, 22, 13, 0, 0),
            TimeSpan.FromHours(-3)
        );

        var result = club.IsOpen(dateTime);
        result.Should().BeFalse();
    }

    [Fact]
    public void IsOpen_RegularSchedule_RespectsHours()
    {
        var club = CreateClub();
        
        club.Schedules.Add(mondaySchedule);


        var monday22June = new DateTimeOffset(
            new DateTime(2026, 6, 22, 13, 0, 0),
            TimeSpan.FromHours(-3)
        ); // Lunes 22 de junio de 2026 a las 13:00 hora local
        
        using (new AssertionScope())
        {
            club.IsOpen(monday22June).Should().BeTrue();

            club.IsOpen(monday22June.AddHours(-2)).Should().BeFalse();

            club.IsOpen(monday22June.AddHours(10)).Should().BeFalse();   
        }

    }

    [Fact]
    public void IsOpen_DayClosure_AffectsOnlyThatDay()
    {
        var club = CreateClub();
        club.Schedules.Add(mondaySchedule);

        var exceptionDate = new DateOnly(2026, 6, 22);
        club.AddScheduleOverride(ClubScheduleOverride.CreateDayClosure(exceptionDate, "Feriado de canchas"));

        var monday22June = new DateTimeOffset(
            new DateTime(2026, 6, 22, 13, 0, 0),
            TimeSpan.FromHours(-3)
        );

        var monday29June = new DateTimeOffset(
            new DateTime(2026, 6, 29, 13, 0, 0),
            TimeSpan.FromHours(-3)
        );


        using (new AssertionScope())
        {
            club.IsOpen(monday22June).Should().BeFalse();
            club.IsOpen(monday29June).Should().BeTrue();
        }
    }

    [Fact]
    public void IsOpen_ModifiedHours_OverridesRegularSchedule()
    {
        var club = CreateClub();
        club.Schedules.Add(mondaySchedule);

        var exceptionDate = new DateOnly(2026, 6, 22);
        club.AddScheduleOverride(ClubScheduleOverride.CreateModifiedHours(
            exceptionDate,
            "Evento especial",
            TimeSpan.FromHours(14),
            TimeSpan.FromHours(20)
        ));

        var monday22JuneAt13 = new DateTimeOffset(
            new DateTime(2026, 6, 22, 13, 0, 0),
            TimeSpan.FromHours(-3)
        );

        var monday22JuneAt15 = new DateTimeOffset(
            new DateTime(2026, 6, 22, 15, 0, 0),
            TimeSpan.FromHours(-3)
        );

        var monday22JuneAt19 = new DateTimeOffset(
            new DateTime(2026, 6, 22, 19, 0, 0),
            TimeSpan.FromHours(-3)
        );

        var monday22JuneAt21 = new DateTimeOffset(
            new DateTime(2026, 6, 22, 21, 0, 0),
            TimeSpan.FromHours(-3)
        );

        using (new AssertionScope())
        {
            club.IsOpen(monday22JuneAt13).Should().BeFalse();
            club.IsOpen(monday22JuneAt15).Should().BeTrue();
            club.IsOpen(monday22JuneAt19).Should().BeTrue();
            club.IsOpen(monday22JuneAt21).Should().BeFalse();
        }
    }

    [Fact]
    public void IsOpen_OvernightSchedule_CoversNextDayMorning()
    {
        var club = CreateClub();
        
        var fridaySchedule = ClubSchedule.Create(
            DayOfWeek.Friday,
            TimeSpan.FromHours(14), 
            TimeSpan.FromHours(02)
        );

        var saturdaySchedule = ClubSchedule.Create(
            DayOfWeek.Saturday,
            TimeSpan.FromHours(14), 
            TimeSpan.FromHours(02)
        );

        club.Schedules.Add(fridaySchedule);
        club.Schedules.Add(saturdaySchedule);

        var saturdayMidnight = new DateTimeOffset(
            new DateTime(2026, 6, 20, 0, 0, 0),
            TimeSpan.FromHours(-3)
        );

        var saturday1AM = new DateTimeOffset(
            new DateTime(2026, 6, 20, 1, 0, 0),
            TimeSpan.FromHours(-3)
        );

        var saturday2AM = new DateTimeOffset(
            new DateTime(2026, 6, 20, 2, 0, 0),
            TimeSpan.FromHours(-3)
        );

        var saturday13PM = new DateTimeOffset(
            new DateTime(2026, 6, 20, 13, 0, 0),
            TimeSpan.FromHours(-3)
        );

        var saturday22PM = new DateTimeOffset(
            new DateTime(2026, 6, 20, 22, 0, 0),
            TimeSpan.FromHours(-3)
        );

        var sunday1AM = new DateTimeOffset(
            new DateTime(2026, 6, 21, 1, 0, 0),
            TimeSpan.FromHours(-3)
        );

        using (new AssertionScope())
        {
            club.IsOpen(saturdayMidnight).Should().BeTrue();
            club.IsOpen(saturday1AM).Should().BeTrue();
            club.IsOpen(saturday2AM).Should().BeFalse();
            club.IsOpen(saturday13PM).Should().BeFalse();
            club.IsOpen(saturday22PM).Should().BeTrue();
            club.IsOpen(sunday1AM).Should().BeTrue();
        }
    }

    [Fact]
    public void RemoveScheduleOverride_ExistingDate_RemovesOverride()
    {
        var club = CreateClub();
        club.Schedules.Add(mondaySchedule);
        
        var date = new DateOnly(2026, 6, 22);
        var overrideToRemove = ClubScheduleOverride.CreateDayClosure(date, "Feriado");
        
        club.AddScheduleOverride(overrideToRemove);
        club.RemoveScheduleOverride(date);
        
        var monday22June17PM = new DateTimeOffset(
            new DateTime(2026, 6, 22, 17, 0, 0),
            TimeSpan.FromHours(-3)
        );

        using (new AssertionScope())
        {
            club.GetScheduleOverride(date).Should().BeNull();
            club.IsOpen(monday22June17PM).Should().BeTrue();
        }
    }

    [Fact]
    public void RemoveScheduleOverride_NonExistingDate_DoesNotThrow()
    {
        var club = CreateClub();
        var nonExistingDate = new DateOnly(2026, 1, 1);

        Action act = () => club.RemoveScheduleOverride(nonExistingDate);

        act.Should().NotThrow();
    }

    [Fact]
    public void GetOpenWindows_Regualar_Case()
    {
        var club = CreateClub();
        club.Schedules.Add(mondaySchedule);

        var date = new DateOnly(2026, 6, 22);

        var windows = club.GetOpenWindows(date);

        windows.Should().ContainSingle()
            .Which.Should().Be((TimeSpan.FromHours(12), TimeSpan.FromHours(23)));
    }

    [Fact]
    public void GetOpenWindows_DayClosure_ReturnsEmpty()
    {
        var club = CreateClub();
        club.Schedules.Add(mondaySchedule);

        var date = new DateOnly(2026, 6, 22);
        club.AddScheduleOverride(ClubScheduleOverride.CreateDayClosure(date, "Feriado"));

        var windows = club.GetOpenWindows(date);

        windows.Should().BeEmpty();
    }

    [Fact]
    public void GetOpenWindows_ModifiedHours_ReturnsOverride()
    {
        var club = CreateClub();
        club.Schedules.Add(mondaySchedule);

        var exceptionDate = new DateOnly(2026, 6, 22);
        club.AddScheduleOverride(ClubScheduleOverride.CreateModifiedHours(
            exceptionDate,
            "Evento especial",
            TimeSpan.FromHours(14),
            TimeSpan.FromHours(20)
        ));

        var windows = club.GetOpenWindows(exceptionDate);

        windows.Should().ContainSingle()
            .Which.Should().Be((TimeSpan.FromHours(14), TimeSpan.FromHours(20)));

    }

    [Fact]
    public void GetOpenWindows_NoSchedules_ReturnsEmpty()
    {
        var club = CreateClub();

        var date = new DateOnly(2026, 6, 22);

        var windows = club.GetOpenWindows(date);

        windows.Should().BeEmpty();
    }

    [Fact]
    public void GetOpenWindows_MultipleSchedules_SameDay_ReturnsMergedWindows()
    {
        var club = CreateClub();

        var schedule1 = ClubSchedule.Create(
            DayOfWeek.Monday,
            TimeSpan.FromHours(8),
            TimeSpan.FromHours(12)
        );

        var schedule2 = ClubSchedule.Create(
            DayOfWeek.Monday,
            TimeSpan.FromHours(14),
            TimeSpan.FromHours(22)
        );

        club.Schedules.Add(schedule1);
        club.Schedules.Add(schedule2);

        var date = new DateOnly(2026, 6, 22);

        var windows = club.GetOpenWindows(date);

        using (new AssertionScope())
        {
            windows.Should().HaveCount(2);
            windows.Should().Contain((TimeSpan.FromHours(8), TimeSpan.FromHours(12)));
            windows.Should().Contain((TimeSpan.FromHours(14), TimeSpan.FromHours(22)));
        }
    }

    [Fact]
    public void GetOpenWindows_OvernightSchedule_ReturnsCorrectWindows()
    {
        var club = CreateClub();

        var fridaySchedule = ClubSchedule.Create(
            DayOfWeek.Friday,
            TimeSpan.FromHours(14), 
            TimeSpan.FromHours(02)
        );

        club.Schedules.Add(fridaySchedule);

        var date = new DateOnly(2026, 6, 19); 
        var nextDate = new DateOnly(2026, 6, 20);  
        var windows = club.GetOpenWindows(date);
        var nextWindows = club.GetOpenWindows(nextDate);

        using (new AssertionScope())
        {
            windows.Should().Contain((TimeSpan.FromHours(14), TimeSpan.FromHours(24)));
            nextWindows.Should().Contain((TimeSpan.Zero, TimeSpan.FromHours(2)));
        }
    }

    [Fact]
    public void GetWindows_OverlappingSchedules_MergesWindows()
    {
        var club = CreateClub();

        var schedule1 = ClubSchedule.Create(
            DayOfWeek.Monday,
            TimeSpan.FromHours(8),
            TimeSpan.FromHours(12)
        );

        var schedule2 = ClubSchedule.Create(
            DayOfWeek.Monday,
            TimeSpan.FromHours(10),
            TimeSpan.FromHours(14)
        );

        club.Schedules.Add(schedule1);
        club.Schedules.Add(schedule2);

        var date = new DateOnly(2026, 6, 22);

        var windows = club.GetOpenWindows(date);

        windows.Should().ContainSingle()
            .Which.Should().Be((TimeSpan.FromHours(8), TimeSpan.FromHours(14)));
    }

    [Fact]
    public void GetWindows_AdjacentSchedules_MergesWindows()
    {
        var club = CreateClub();

        var schedule1 = ClubSchedule.Create(
            DayOfWeek.Monday,
            TimeSpan.FromHours(8),
            TimeSpan.FromHours(12)
        );

        var schedule2 = ClubSchedule.Create(
            DayOfWeek.Monday,
            TimeSpan.FromHours(12),
            TimeSpan.FromHours(14)
        );

        club.Schedules.Add(schedule1);
        club.Schedules.Add(schedule2);

        var date = new DateOnly(2026, 6, 22);

        var windows = club.GetOpenWindows(date);

        windows.Should().ContainSingle()
            .Which.Should().Be((TimeSpan.FromHours(8), TimeSpan.FromHours(14)));
    }

    [Fact]
    public void GetWindows_RemovedScheduleOverride_ReturnsBaseWindows()
    {   
        var club = CreateClub();
        club.Schedules.Add(mondaySchedule);

        var date = new DateOnly(2026, 6, 22);
        var scheduleOverride = ClubScheduleOverride.CreateDayClosure(date, "Feriado");
        
        club.AddScheduleOverride(scheduleOverride);
        club.RemoveScheduleOverride(date);

        var windows = club.GetOpenWindows(date);

        windows.Should().ContainSingle()
            .Which.Should().Be((TimeSpan.FromHours(12), TimeSpan.FromHours(23)));
        
    }

    [Fact]
    public void GetWindows_MultipleOverrides_ReturnsMostRestrictive()
    {
        var club = CreateClub();
        club.Schedules.Add(mondaySchedule);

        var date = new DateOnly(2026, 6, 22);
        var modifiedHoursOverride = ClubScheduleOverride.CreateModifiedHours(
            date,
            "Evento especial",
            TimeSpan.FromHours(14),
            TimeSpan.FromHours(20)
        );
        
        var closureOverride = ClubScheduleOverride.CreateDayClosure(date, "Feriado");

        club.AddScheduleOverride(modifiedHoursOverride);
        club.AddScheduleOverride(closureOverride); 

        var windows = club.GetOpenWindows(date);

        windows.Should().BeEmpty(); 
    }

    [Fact]
    public void GetBaseWindows_ReturnsBaseWindows()
    {
        var club = CreateClub();
        club.Schedules.Add(mondaySchedule);

        var date = new DateOnly(2026, 6, 22);
        var windows = club.GetBaseWindows(date);
        windows.Should().ContainSingle()
            .Which.Should().Be((TimeSpan.FromHours(12), TimeSpan.FromHours(23)));
    }


}
