namespace App.Domain.Entities
{
    public class TaskEntryEntity:BaseEntity
    {
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
        public int TimeSpent { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual TaskEntity Task { get; set; }

    }
}