namespace TaskManagerAPI.Models.Domain;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    
    // Foreign Keys
    public Guid RoleId { get; set; }
    
}