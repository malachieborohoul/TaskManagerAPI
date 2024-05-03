using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Models.Domain;
using TaskManagerAPI.Repositories;


namespace StatusManagerAPI.Repositories;

public class SQLStatusRepository:IStatusRepository
{
    private readonly TaskManagerDbContext _dbContext;

    public SQLStatusRepository(TaskManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Status>> GetAll()
    {
        return await _dbContext.Status.ToListAsync();
    }

    public async Task<Status?> GetById(Guid id)
    {
        return await _dbContext.Status.FindAsync(id);
    }

    public async Task<Status> Create(Status Status)
    {
         await _dbContext.Status.AddAsync(Status);
         await _dbContext.SaveChangesAsync();

         return Status;

    }

    public async Task<Status?> Update(Guid id, Status Status)
    {
        var existingStatus = await _dbContext.Status.FindAsync(id);

        if (existingStatus == null)
        {
            return null;
            
        }

        existingStatus.Name = Status.Name;
       

        await _dbContext.SaveChangesAsync();
        return existingStatus;
        
    }

    public async Task<Status?> Delete(Guid id)
    {
        var existingStatus = await _dbContext.Status.FindAsync(id);

        if (existingStatus == null)
        {
            return null;
            
        }

        ;

         _dbContext.Status.Remove(existingStatus);
        return existingStatus;
    }
}