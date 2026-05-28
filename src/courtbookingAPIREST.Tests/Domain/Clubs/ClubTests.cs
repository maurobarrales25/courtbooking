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
    public void IsOpen_ReturnsCorrectResultsForDifferentTimes()
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
    public void IsOpen_ReturnsFalseWhenClosedByException()
    {
        var club = CreateClub();
        club.Schedules.Add(mondaySchedule);

        var exceptionDate = new DateOnly(2026, 6, 22);
        club.AddScheduleOverride(ClubScheduleOverride.CreateClosure(exceptionDate, "Feriado de canchas"));

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
    public void IsOpen_ReturnsTrueWhenModifiedHoursException()
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

}
