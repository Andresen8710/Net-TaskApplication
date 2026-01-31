using App.Common.Classes.Base.Repository;
using App.Infraestructure.DataBase.Context;
using App.Domain.Entities;
using App.Domain.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.Infraestructure.Repositories.User
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public ApplicationContext Context
        {
            get
            {
                return (ApplicationContext)_context;
            }
        }

        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<UserEntity> GetByUserNameAsync(string userName)
        {
            var result= _Table.Include(u=>u.Role)
                .Where(w => w.UserName.Equals(userName)).FirstOrDefault();

            return result;
        }
    }
}