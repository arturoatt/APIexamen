using APIexamen.DTOs;

namespace APIexamen.IServices
{
    public interface IRepository<T > where T : class
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(PaginationDTO pagination);
        Task<T> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(int id);
    }
}
