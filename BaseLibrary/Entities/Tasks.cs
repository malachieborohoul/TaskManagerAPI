namespace BaseLibrary.Entities;

public class Tasks
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    
    // Foreign Keys
    public Guid StatusId { get; set; }
    public Guid UserId { get; set; }
    
    
}