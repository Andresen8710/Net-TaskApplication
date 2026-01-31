using App.Common.Classes.Base.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.Common.Classes.Base.Services
{
    public abstract class BaseService<TDTO, TEntity> : IBaseService<TDTO> where TDTO : class where TEntity : class
    {
        public readonly IBaseRepository<TEntity> _repository;
        public readonly IConfiguration _configuration;
        public readonly IMapper _mapper;

        public BaseService(Repository.IBaseRepository<TEntity> repository, IConfiguration configuration, IMapper mapper)
        {
            _repository = repository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public virtual async Task<IEnumerable<TDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAll().ToListAsync();
            var list = _mapper.Map<List<TDTO>>(entities);
            return list;
        }

        public virtual async Task<TDTO> CreateAsync(TDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(string.Format("Request Null"));

            TEntity entity = _mapper.Map<TEntity>(dto);

            entity = await _repository.CreateAsync(entity);

            return _mapper.Map<TDTO>(entity);
        }

        public virtual  async Task<TDTO> FindByIdAsync(object id)
        {
            TEntity entity = await _repository.FindByIdAsync(id);

            return _mapper.Map<TDTO>(entity);
        }

        public virtual async Task<TDTO> UpdateAsync(TDTO dto)
        {
            TEntity entity=_mapper.Map<TEntity>(dto);

            entity = await _repository.UpdateAsync(entity);

            return _mapper.Map<TDTO>(entity);
        }

        public virtual async Task<TDTO> DeleteAsync(Guid id)
        {
           var result= await _repository.DeleteAsync(id);

            return _mapper.Map<TDTO>(result);
        }
    }
}