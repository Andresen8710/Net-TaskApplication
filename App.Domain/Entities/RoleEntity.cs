namespace App.Domain.Entities
{
    public class RoleEntity:BaseEntity
    {

        public RoleEntity()
        {
            Users = new HashSet<UserEntity>();
        }
        public string? Name { get; set; }

        public virtual ICollection<UserEntity> Users { get; set; }
    }
}