namespace TaskManagerAPI.Models.Domain;

public class Task
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    
    // Foreign Keys
    public Status Status { get; set; }
    public User User { get; set; }
    
    
}