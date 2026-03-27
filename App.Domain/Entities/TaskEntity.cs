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
		public DateTime StartDate { get; set; }
		public DateTime DueDate { get; set; }
		public int EstimatedTime { get; set; }
		public Guid StatusId { get; set; }

		public virtual UserEntity User { get; set; }
        public virtual PriorityEntity Priority { get; set; }
        public virtual ICollection<TaskEntryEntity> TaskEntries { get; set; }
        public virtual TaskStatus TaskStatus { get; set; }

	}
}