namespace App.Common.Classes.Base.Services
{
    public interface IBaseService<TDTO> where TDTO : class
    {

        Task<IEnumerable<TDTO>> GetAllAsync();

        Task<TDTO> FindByIdAsync(object Id);

        Task<TDTO> CreateAsync(TDTO dto);

        Task<TDTO> UpdateAsync(TDTO dto);

        Task<TDTO>DeleteAsync(Guid id);

        //Task SaveChangesAsync();
    }
}