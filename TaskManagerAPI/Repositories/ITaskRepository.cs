using Task = TaskManagerAPI.Models.Domain.Task;

namespace TaskManagerAPI.Repositories;

public interface ITaskRepository
{
    Task<List<Task>> GetAll();

    Task<Task?> GetById(Guid id);

    Task<Task> Create(Task task);

    Task<Task?> Update(Guid id, Task task);

    Task<Task?> Delete(Guid id);
}