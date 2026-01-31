namespace App.Common.Classes.Base.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        Task<T> FindByIdAsync(object Id);

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);
        
        Task<T> DeleteAsync(Guid id);
    }
}