namespace courtbookingAPIREST.Domain.AdminsClubs.Exceptions;

public class AdminClubNotFoundException(AdminClubId id)
    : Exception($"AdminClub con id {id} no encontrado.");