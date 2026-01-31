namespace App.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public UserEntity()
        {
            Tasks= new HashSet<TaskEntity>();
            TaskEntries = new HashSet<TaskEntryEntity>();
        }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Guid RoleId { get; set; }
        public bool IsAdmin { get; set; }
        public string UserName { get; set; }= string.Empty;

        public virtual RoleEntity? Role { get; set; }
        public virtual ICollection<TaskEntity> Tasks { get; set; }
        public virtual ICollection<TaskEntryEntity> TaskEntries { get; set; }
    }
}