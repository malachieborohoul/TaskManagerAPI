


using TaskManagerAPI.Models.Domain;

namespace TaskManagerAPI.Repositories;

public interface IStatusRepository
{
    Task<List<Status>> GetAll();

    Task<Status?> GetById(Guid id);

    Task<Status> Create(Status status);

    Task<Status?> Update(Guid id, Status status);

    Task<Status?> Delete(Guid id);
}
