using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Models.Domain;
using Task = TaskManagerAPI.Models.Domain.Task;

namespace TaskManagerAPI.Data;

public class TaskManagerDbContext:DbContext
{
    public TaskManagerDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
    {
       
    }
    
    public DbSet<Role> Roles { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
}