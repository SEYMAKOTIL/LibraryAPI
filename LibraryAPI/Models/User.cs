public enum Role
{
    Admin,
    User
}

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public byte[] PasswordHash { get; set; } = null!;
    public byte[] PasswordSalt { get; set; } = null!;
    public Role Role { get; set; }
}
