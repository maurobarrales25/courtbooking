namespace courtbookingAPIREST.Domain.AdminsClubs.Exceptions;

public class AdminClubInvalidStatusException(string mensaje)
    : Exception(mensaje);