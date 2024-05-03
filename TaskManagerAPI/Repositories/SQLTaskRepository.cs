using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Models.Domain;

namespace TaskManagerAPI.Repositories;

public class SQLTaskRepository:ITaskRepository
{
    private readonly TaskManagerDbContext _dbContext;

    public SQLTaskRepository(TaskManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Tasks>> GetAll()
    {
        return await _dbContext.Tasks.ToListAsync();
    }

    public async Task<Tasks?> GetById(Guid id)
    {
        return await _dbContext.Tasks.FindAsync(id);
    }

    public async Task<Tasks> Create(Tasks task)
    {
         await _dbContext.Tasks.AddAsync(task);
         await _dbContext.SaveChangesAsync();

         return task;

    }

    public async Task<Tasks?> Update(Guid id, Tasks task)
    {
        var existingTask = await _dbContext.Tasks.FindAsync(id);

        if (existingTask == null)
        {
            return null;
            
        }

        existingTask.Title = task.Title;
        existingTask.Description = task.Description;
        existingTask.DueDate = task.DueDate;

        await _dbContext.SaveChangesAsync();
        return existingTask;
        
    }

    public async Task<Tasks?> Delete(Guid id)
    {
        var existingTask = await _dbContext.Tasks.FindAsync(id);

        if (existingTask == null)
        {
            return null;
            
        }

        ;

         _dbContext.Tasks.Remove(existingTask);
        return existingTask;
    }
}