namespace App.Domain.Entities
{
    public class TaskEntity : BaseEntity
    {

        public TaskEntity()
        {
            TaskEntries = new HashSet<TaskEntryEntity>();
        }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid PriorityId { get; set; }
        public Guid UserId { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual PriorityEntity Priority { get; set; }
        public virtual ICollection<TaskEntryEntity> TaskEntries { get; set; }

    }
}