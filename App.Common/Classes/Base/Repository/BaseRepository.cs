using App.Common.Classes.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace App.Common.Classes.Base.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DbContext _context;
        protected DbSet<TEntity> _Table;

        protected BaseRepository(DbContext context)
        {
            _context = context;
            _Table = _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _Table.AsQueryable();
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            try
            {
                await _Table.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public virtual async Task<TEntity> FindByIdAsync(object id)
        {
            object obj = CastPrimaryKey(id);
            return await _Table.FindAsync(obj);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            TEntity oldRecord = await FindByIdAsync(entity.GetPrimaryKeyValue());
            _context.Entry(oldRecord).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> DeleteAsync(Guid id)
        {
            var existingEntity = await _context.Set<TEntity>().FindAsync(id);

            if (existingEntity == null) { throw new ApplicationException("Record Not Found."); }

            // _context.Remove(existingEntity);
            //Verify if the entity has the IsDeleted Property
            var isDeletedProp = typeof(TEntity).GetProperty("IsDeleted");

            if (isDeletedProp != null && isDeletedProp.PropertyType==typeof(bool)) 
            { 
                var isDeleted = (bool)isDeletedProp.GetValue(existingEntity);
                if (isDeleted)
                {
                    throw new ApplicationException("Record already logically Deleted");
                }

                isDeletedProp.SetValue(existingEntity, true);
                _context.Update(existingEntity);
            }
            else
            {
				throw new ApplicationException($"The entity {typeof(TEntity).Name} does not support logical delete (IsDeleted property not found).");
			}    

                await _context.SaveChangesAsync();
            return existingEntity;
        }

        //
        // Summary:
        //     Obtiene la clave primeria
        //
        // Parameters:
        //   id:
        //     Identificador
        protected object CastPrimaryKey(object id)
        {
            string primaryKeyName = GetPrimaryKeyName();
            Type propertyType = typeof(TEntity).GetProperty(primaryKeyName).PropertyType;
            return Convert.ChangeType(id, propertyType);
        }

        //
        // Summary:
        //     Obtiene la clave primaria
        //
        // Returns:
        //     String con la clave primaria
        protected string GetPrimaryKeyName()
        {
            IEnumerable<string> source = _context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties.Select((IProperty x) => x.Name);
            string text = source.FirstOrDefault();
            if (source.Count() > 1)
            {
                throw new ApplicationException("El objeto tiene mas de 1 llave primaria. Lo cual no permite la automatización de BaseModel en el Update");
            }

            if (text == null)
            {
                throw new ApplicationException("El objeto no tiene llave primaria. Lo cual no permite la automatización de BaseModel en el Update");
            }

            return text;
        }
    }
}