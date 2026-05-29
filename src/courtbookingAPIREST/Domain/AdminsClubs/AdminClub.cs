namespace courtbookingAPIREST.Domain.AdminsClubs;

using courtbookingAPIREST.Domain.AdminsClubs.Exceptions;
using courtbookingAPIREST.Domain.Clubs; // Cada Admin tiene un club.
public class AdminClub
{
    public AdminClubId Id { get; private set; }
    public ClubID ClubId { get; private set; }
    public string AuthProviderId { get; private set; } // sub del JWT Supabase
    public string AuthProvider { get; private set; }   // "google" | "local"
    public string Name { get; private set; }
    public string Email { get; private set; }
    public bool IsOwner { get; private set; }
    public AdminClubStatus Status { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }
    public DateTime LastLoginAtUtc { get; private set; }
    public string? Phone { get; private set; }
    public Guid? ApprovedBy { get; private set; }
    public DateTime? ApprovedAt { get; private set; }
    // Soft delete
    public DateTime? RemovedAt { get; private set; }
    public Guid? RemovedBy { get; private set; }
    // Transferencia de ownership
    public DateTime? OwnershipTransferredAt { get; private set; }
    public Guid? OwnershipTransferredTo { get; private set; }
    private AdminClub()
    {
        AuthProviderId = null!;
        AuthProvider = null!;
        Name = null!;
        Email = null!;
    }

    public static AdminClub Create(ClubID clubId, string authProviderId, 
        string authProvider, string name, string email, bool isOwner) => new()
    {
        Id = AdminClubId.New(),
        ClubId = clubId,
        AuthProviderId = authProviderId,
        AuthProvider = authProvider,
        Name = name,
        Email = email,
        IsOwner = isOwner,
        Status = isOwner ? AdminClubStatus.Activo : AdminClubStatus.Pendiente,
        CreatedAtUtc = DateTime.UtcNow,
        LastLoginAtUtc = DateTime.UtcNow
    };
    public void Approve()
    {
        if (Status != AdminClubStatus.Pendiente)
            throw new AdminClubInvalidStatusException("Solo se puede aprobar un admin pendiente.");
        Status = AdminClubStatus.Activo;
    }

    public void Deactivate()
    {
        if (Status != AdminClubStatus.Activo)
            throw new AdminClubInvalidStatusException("Solo se puede desactivar un admin activo.");
        Status = AdminClubStatus.Inactivo;
    }

    public void RegisterLogin()
    {
        LastLoginAtUtc = DateTime.UtcNow;
    }

    public void Remove(Guid removedBy)
    {
        if (Status == AdminClubStatus.Inactivo)
            throw new AdminClubInvalidStatusException("El admin ya fue removido.");
        RemovedAt = DateTime.UtcNow;
        RemovedBy = removedBy;
        Status = AdminClubStatus.Inactivo;
    }

    public void TransferOwnership(Guid newOwnerId)
    {
        if (!IsOwner)
            throw new AdminClubInvalidStatusException("Solo el owner puede transferir ownership.");
        OwnershipTransferredAt = DateTime.UtcNow;
        OwnershipTransferredTo = newOwnerId;
        IsOwner = false;
    }

    public void SetApprovedBy(Guid approvedBy)
    {
        ApprovedBy = approvedBy;
        ApprovedAt = DateTime.UtcNow;
    }
    
}