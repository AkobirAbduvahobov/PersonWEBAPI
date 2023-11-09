namespace PersonWEBAPI.Application.Repositories;

public interface IRepository<T>
{
    Task<T> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<bool> UpdateAsync(T entity);
    Task<T> CreateAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
}
