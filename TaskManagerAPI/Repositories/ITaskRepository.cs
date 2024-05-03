


using TaskManagerAPI.Models.Domain;

namespace TaskManagerAPI.Repositories;

public interface ITaskRepository
{
    Task<List<Tasks>> GetAll();

    Task<Tasks?> GetById(Guid id);

    Task<Tasks> Create(Tasks task);

    Task<Tasks?> Update(Guid id, Tasks task);

    Task<Tasks?> Delete(Guid id);
}
