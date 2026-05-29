public readonly record struct AdminClubId(Guid Value)
{
    public static AdminClubId New() => new(Guid.NewGuid());
    public static AdminClubId From(Guid value) => new(value);
    public override string ToString() => Value.ToString();
}